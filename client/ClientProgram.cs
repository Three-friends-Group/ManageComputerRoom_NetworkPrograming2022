using common;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace client
{
    public class ClientProgram
    {
        private const int BUFFER_SIZE = 5000 * 1024;
        TcpClient tcpClient;
        IPAddress svIP;
        int svPort, remotePort;
        Thread listenThread, remoteThread;

        LockScreen lockScreen;

        public ClientProgram(string ip, int server_port, int port_remote)
        {
            svIP = IPAddress.Parse(ip);
            svPort = server_port;
            remotePort = port_remote;
        }


        private event Action<string> _onReceievedMessage;
        public event Action<string> OnReceiveMessage
        {
            add { _onReceievedMessage += value; }
            remove { _onReceievedMessage -= value; }
        }

        private event Action<string> _onRemoteDesktop;
        public event Action<string> OnRemoteDesktop
        {
            add { _onRemoteDesktop += value; }
            remove { _onRemoteDesktop -= value; }
        }


        public void Connect()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(svIP, svPort);
                Console.WriteLine("Ket noi thanh cong");
                SendInfo();

                //luồng lắng nghe tin nhắn và lệnh
                listenThread = new Thread(Receive);
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Không thể kết nối đến server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //ClientProgram x = this;
            //lockScreen = new LockScreen(x);
            //lockScreen.Show();


        }


        public void Close()
        {
            if (!tcpClient.Connected)
            {
                tcpClient.Close();
            }
        }
        public void Receive()
        {
            NetworkStream netStream = tcpClient.GetStream();
            try
            {
                while (true)
                {
                    byte[] data = new byte[tcpClient.ReceiveBufferSize];
                    netStream.Read(data, 0, tcpClient.ReceiveBufferSize);
                    DataMethods dataMethods = DataMethods.Deserialize(data);
                    Console.WriteLine("Log: data gui den la: " + dataMethods.Type + (string)dataMethods.Data);

                    switch (dataMethods.Type)
                    {
                        case DataMethodsType.SendMessageToOne:
                            {
                                Console.WriteLine("Log: " + dataMethods.Data.ToString());
                                if (_onReceievedMessage != null)
                                {
                                    _onReceievedMessage(dataMethods.Data.ToString());
                                }
                                break;
                            }

                        case DataMethodsType.RemoteDesktop:
                            {
                                remoteThread = new Thread(RemoteDesktop);
                                remoteThread.Start();
                                break;
                            }

                        case DataMethodsType.MouseLeftRemoteClick:
                            {
                                SetCursorPos(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                mouseLeft(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                break;
                            }
                        case DataMethodsType.MouseRightRemoteClick:
                            {
                                SetCursorPos(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                mouseRight(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                break;
                            }
                        case DataMethodsType.MouseLeftRemoteDoubleClick:
                            {
                                SetCursorPos(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                mouseLeft(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                mouseLeft(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                break;
                            }

                        case DataMethodsType.MouseRightRemoteDoubleClick:
                            {
                                SetCursorPos(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                mouseRight(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                mouseRight(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                break;
                            }

                        case DataMethodsType.MouseRemoteMove:
                            {
                                SetCursorPos(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                break;
                            }
                        case DataMethodsType.KeyRemotePress:
                            {
                                keyDown((Keys)int.Parse(dataMethods.Data.ToString()));
                                keyUp((Keys)int.Parse(dataMethods.Data.ToString()));
                                break;
                            }
                        case DataMethodsType.Shutdown:
                            {
                                Process process = new Process();
                                ProcessStartInfo proccessInfo = new ProcessStartInfo();
                                proccessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                proccessInfo.FileName = "shutdown.exe";
                                proccessInfo.Arguments = "/f -s -t 00";
                                process.StartInfo = proccessInfo;
                                process.Start();
                                this.Close();
                                break;
                            }
                        case DataMethodsType.Restart:
                            {
                                Process process = new Process();
                                ProcessStartInfo proccessInfo = new ProcessStartInfo();
                                proccessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                proccessInfo.FileName = "shutdown.exe";
                                proccessInfo.Arguments = "/f -r -t 00";
                                process.StartInfo = proccessInfo;
                                process.Start();
                                this.Close();

                                break;
                            }
                        case DataMethodsType.LockMouseAndKeyBoard:
                            {
                                MessageBox.Show("Lock keyboard and mouse");
                                break;
                            }


                    }



                }
            }
            catch
            {
                listenThread.Abort();
            }

        }

        private void RemoteDesktop()
        {
            TcpClient tcpRemote = new TcpClient();

            try
            {
                tcpRemote.Connect(svIP, remotePort);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            NetworkStream netStream = tcpRemote.GetStream();
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            gfxScreenshot.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            gfxScreenshot.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            gfxScreenshot.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            BinaryFormatter format = new BinaryFormatter();
            Image image;
            while (true)
            {
                try
                {
                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                    image = bmpScreenshot;
                    format.Serialize(netStream, image);
                }
                catch
                {
                    break;
                }
            }
            remoteThread.Abort();
        }

        public void Send(DataMethods data)
        {
            NetworkStream netStream = tcpClient.GetStream();
            try
            {
                if (data == null)
                {
                    throw new ArgumentException("Dữ liệu null");
                }
                Console.WriteLine("Log: chao");
                netStream.Write(data.Serialize(), 0, data.Serialize().Length);
                Console.WriteLine("Log: chao2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendInfo()
        {
            string name = Dns.GetHostName();
            Console.WriteLine("Ten pc la: " + name);
            DataMethods dataSend = new DataMethods(DataMethodsType.SendName, name);
            Console.WriteLine("Log: data send tu client: " + dataSend.Type.ToString() + dataSend.Data.ToString());
            //DataMethods dataMethods = new DataMethods(DataMethodsType.SendInfo, name);

            Send(dataSend);
            //string msg;
            //msg = "NAME|" + Dns.GetHostName();
            //sendMsg(msg);
            //Thread.Sleep(1000);
            //IPEndPoint ipEP = (IPEndPoint)_tcpClient.Client.RemoteEndPoint;
            //IPAddress ipAdd = ipEP.Address;
            //msg = "IP|" + ipAdd.ToString();
            //sendMsg(msg);
        }

        #region mouse and key handle remote
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool fBlockIt);
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const int KEYEVENTF_KEYUP = 0x0002;

        private void mouseLeft(int x, int y)
        {
            mouse_event((uint)MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, 0);
            mouse_event((uint)MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);
        }

        private void mouseRight(int x, int y)
        {
            mouse_event((uint)MOUSEEVENTF_RIGHTDOWN, (uint)x, (uint)y, 0, 0);
            mouse_event((uint)MOUSEEVENTF_RIGHTUP, (uint)x, (uint)y, 0, 0);
        }

        private void keyUp(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }

        private void keyDown(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);
        }
        #endregion

    }
}
