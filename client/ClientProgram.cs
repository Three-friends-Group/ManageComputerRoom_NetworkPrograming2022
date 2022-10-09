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
                    Console.WriteLine(dataMethods.Type + (string)dataMethods.Data);

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

    }
}
