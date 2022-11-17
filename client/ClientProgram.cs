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
using server;
using System.IO;

namespace client
{
    public class ClientProgram
    {
        TcpClient tcpClient, tcpRemote;
        NetworkStream netStreamRemote;
        IPAddress svIP;
        int svPort, remotePort;
        Thread listenThread, remoteThread, rmEventsThread;

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

        private event Action<string> _onServerOff;
        public event Action<string> OnServerOff
        {
            add { _onServerOff += value; }
            remove { _onServerOff -= value; }
        }

        public Action OnLockScreen;
        public Action OnUnLockScreen;


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
                listenThread = new Thread(Receive);
                listenThread.IsBackground = true;
                listenThread.Start();
                return;
            }
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
            NetworkStream netStreamRm = tcpClient.GetStream();
            try
            {
                while (true)
                {
                    byte[] data = new byte[tcpClient.ReceiveBufferSize];
                    netStreamRm.Read(data, 0, tcpClient.ReceiveBufferSize);
                    DataMethods dataMethods = DataMethods.Deserialize(data);
                    Console.WriteLine("Log: data gui den la: " + dataMethods.Type + (string)dataMethods.Data);

                    switch (dataMethods.Type)
                    {
                        case DataMethodsType.SendMessageToAll:
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

                                try
                                {
                                    tcpRemote = new TcpClient();
                                    tcpRemote.Connect(svIP, remotePort);
                                    netStreamRemote = tcpRemote.GetStream();
                                    rmEventsThread = new Thread(WaitForCommands);
                                    rmEventsThread.IsBackground = true;
                                    rmEventsThread.Start();
                                    Thread.Sleep(500);
                                    remoteThread = new Thread(RemoteDesktop);
                                    remoteThread.IsBackground = true;
                                    remoteThread.Start();
                                }
                                catch
                                {
                                    MessageBox.Show("Không thể kết nối đến Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }

                                break;
                            }
                        case DataMethodsType.ExitRemote:
                            {
                                tcpRemote.Close();
                                rmEventsThread.Abort();
                                remoteThread.Abort();
                                break;
                            }


                        case DataMethodsType.Shutdown:
                            {
                                MessageBox.Show("Máy sẽ tắt lại sau " + dataMethods.Data.ToString() + " phút");
                                Process process = new Process();
                                ProcessStartInfo proccessInfo = new ProcessStartInfo();
                                proccessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                proccessInfo.FileName = "shutdown.exe";
                                proccessInfo.Arguments = "/f -s -t " + dataMethods.Data.ToString();
                                process.StartInfo = proccessInfo;
                                process.Start();
                                this.Close();
                                break;
                            }
                        case DataMethodsType.Restart:
                            {
                                MessageBox.Show("Máy sẽ khởi động lại sau " + dataMethods.Data.ToString() + " phút");
                                Process process = new Process();
                                ProcessStartInfo proccessInfo = new ProcessStartInfo();
                                proccessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                proccessInfo.FileName = "shutdown.exe";
                                proccessInfo.Arguments = "/f -s -t " + dataMethods.Data.ToString();
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
                        case DataMethodsType.LockScreen:
                            {
                                if (OnLockScreen != null)
                                {
                                    OnLockScreen();
                                }
                                break;
                            }
                        case DataMethodsType.UnlockScreen:
                            {
                                if (OnUnLockScreen != null)
                                {
                                    OnUnLockScreen();
                                }
                                break;

                            }
                        case DataMethodsType.Exit:
                            {
                                Close();
                                if (_onServerOff != null)
                                {
                                    _onServerOff("");
                                }

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

        private void WaitForCommands()
        {

            while (true)
            {
                try
                {
                    byte[] data = new byte[tcpClient.ReceiveBufferSize];
                    netStreamRemote.Read(data, 0, tcpClient.ReceiveBufferSize);
                    DataMethods dataMethods = DataMethods.Deserialize(data);
                    switch (dataMethods.Type)
                    {
                        case DataMethodsType.LCLICK:
                            {
                                //SetCursorPos(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                //mouseLeft(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                break;
                            }
                        case DataMethodsType.RCLICK:
                            {
                                RemoteEvent.mouse_event(RemoteEvent.MOUSEEVENTF_RIGHTDOWN | RemoteEvent.MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);

                                //SetCursorPos(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                //mouseRight(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                break;
                            }
                        case DataMethodsType.LDCLICK:
                            {
                                //SetCursorPos(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                //mouseLeft(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                //mouseLeft(int.Parse(dataMethods.Data.ToString().Split('|')[0]), int.Parse(dataMethods.Data.ToString().Split('|')[1]));
                                break;
                            }

                        case DataMethodsType.RDCLICK:
                            {
                                RemoteEvent.mouse_event(RemoteEvent.MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                                break;
                            }

                        case DataMethodsType.LDOWN:
                            {
                                RemoteEvent.mouse_event(RemoteEvent.MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);

                                break;
                            }
                        case DataMethodsType.LUP:
                            {
                                RemoteEvent.mouse_event(RemoteEvent.MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                                break;
                            }
                        case DataMethodsType.RDOWN:
                            {
                                RemoteEvent.mouse_event(RemoteEvent.MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                                break;
                            }
                        case DataMethodsType.RUP:
                            {
                                RemoteEvent.mouse_event(RemoteEvent.MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);

                                break;
                            }

                        case DataMethodsType.MOVE:
                            {
                                //RemoteEvent.(, );
                                int xPos = 0, yPos = 0;
                                try
                                {
                                    xPos = int.Parse(dataMethods.Data.ToString().Split('|')[0]);
                                    yPos = int.Parse(dataMethods.Data.ToString().Split('|')[1]);
                                    Cursor.Position = new Point(xPos, yPos);
                                }
                                catch
                                {

                                }
                                break;
                            }
                        case DataMethodsType.KEYPRESS:
                            {
                                break;
                            }


                    }
                }
                catch (Exception e)
                {
                    rmEventsThread.Abort();
                    remoteThread.Abort();
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void RemoteDesktop()
        {
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
                    format.Serialize(netStreamRemote, image);
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

            Send(dataSend);
        }
    }
}
