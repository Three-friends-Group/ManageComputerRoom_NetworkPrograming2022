using common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public class ClientProgram
    {
        private const int BUFFER_SIZE = 5000 * 1024;

        IPEndPoint IP;
        Socket client;
        LockScreen lockScreen;


        private event Action<string> _onReceievedMessage;
        public event Action<string> OnReceiveMessage
        {
            add { _onReceievedMessage += value; }
            remove { _onReceievedMessage -= value; }
        }

        public void Connect(string hostname, int port)
        {
            IP = new IPEndPoint(IPAddress.Parse(hostname), port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            //string computerName = System.Environment.MachineName;

            try
            {
                client.Connect(IP);
                Console.WriteLine("Ket noi thanh cong");
                SendName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();

            //ClientProgram x = this;
            //lockScreen = new LockScreen(x);
            //lockScreen.Show();


        }


        public void Close()
        {
            if (!client.Connected)
            {
                client.Close();
            }
        }
        public void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[BUFFER_SIZE];
                    client.Receive(data);
                    DataMethods dataMethods = DataMethods.Deserialize(data);
                    Console.WriteLine(dataMethods.Type +(string) dataMethods.Data);

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
                    }



                }
            }
            catch
            {
                Close();
            }

        }

        public void Send(DataMethods data)
        {
            try
            {
                if (data == null)
                {
                    throw new ArgumentException("Dữ liệu null");
                }

                Console.WriteLine("Log: chao");
                client.Send(data.Serialize());
                Console.WriteLine("Log: chao2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendName()
        {
            string name = Dns.GetHostName();
            Console.WriteLine("Ten pc la: " + name);
            DataMethods dataSend = new DataMethods(DataMethodsType.SendNamePc, name);
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
