using common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public class ServerProgram
    {
        private const int PORT = 9998;
        private const int BUFFER_SIZE = 1024 * 5000;

        IPEndPoint IP;
        Socket server;
        List<Socket> clientSockets;

        public ClientInfoManager clientInfoManager;
        private event Action<List<ClientInfo>> _onClientListChanged;
        public event Action<List<ClientInfo>> OnClientListChanged
        {
            add { _onClientListChanged += value; }
            remove { _onClientListChanged -= value; }
        }
        //event Action<IPEndPoint> _onServerStarted;
        //public event Action<IPEndPoint> OnServerStarted
        //{
        //    add { _onServerStarted += value; }
        //    remove { _onServerStarted -= value; }
        //}

        static private ServerProgram _instance;
        static public ServerProgram Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServerProgram();
                }
                return _instance;

            }
            private set { }
        }

        public ServerProgram()
        {
            clientSockets = new List<Socket>();
            clientInfoManager = new ClientInfoManager();
        }


        #region Methods

        /// <summary>
        /// hàm tạo connect server 
        /// </summary>
        public void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);
            Thread listen = new Thread(StartAceptClient);
            listen.IsBackground = true;
            listen.Start();

            //IPEndPoint serverIP = null;
            //var hostName = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (var ip in hostName.AddressList)
            //{
            //    if (ip.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        serverIP = new IPEndPoint(ip, PORT);
            //        break;
            //    }
            //}
        }

        /// <summary>
        /// lắng nghe kết nối từ client
        /// </summary>
        public void StartAceptClient()
        {
            try
            {
                while (true)
                {
                    server.Listen(100);
                    Socket clientSocket = server.Accept();
                    clientSockets.Add(clientSocket);


                    string[] endpoint = clientSocket.RemoteEndPoint.ToString().Split(':');
                    string clientIP = endpoint[0];
                    string clientPort = endpoint[1];
                    ClientInfo clientInfo = clientInfoManager.FindByIdAndPort(clientIP, clientPort);
                    if (clientInfo == null)
                    {
                        clientInfo = new ClientInfo();
                        clientInfoManager.Add(clientInfo);
                    }

                    byte[] data = new byte[BUFFER_SIZE];
                    clientSocket.Receive(data);
                    DataMethods dataMethods = (DataMethods)DataMethods.Deserialize(data);
                    if (dataMethods.Type == DataMethodsType.SendNamePc)
                    {
                        clientInfo._name = dataMethods.Data as String;
                    }
                    clientInfo._port = clientPort;
                    clientInfo._endpoint = clientSocket.RemoteEndPoint as IPEndPoint;
                    clientInfo._clientIP = clientIP;
                    clientInfo._status = ClientInfoStatus.Connected;
                    clientInfo._socket = clientSocket;


                    //luồng lắng nghe tin nhắn
                    clientInfo._thread = new Thread(() => Receive(clientSocket, clientInfo));
                    clientInfo._thread.IsBackground = true;
                    clientInfo._thread.Start();

                    clientInfoManager.xuat();
                    if (_onClientListChanged != null)
                    {
                        _onClientListChanged(clientInfoManager.Clients);
                    }
                }
            }
            catch
            {
                IP = new IPEndPoint(IPAddress.Any, PORT);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            }
        }


        /// <summary>
        /// ngắt kết nối
        /// </summary>
        public void Close()
        {
            server.Close();
        }

        public void Receive(Socket client, ClientInfo clientInfo)
        {
            //Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[BUFFER_SIZE];
                    client.Receive(data);

                    DataMethods dataMethods = (DataMethods)DataMethods.Deserialize(data);
                    switch (dataMethods.Type)
                    {
                        default:
                            break;
                    }
                }
            }
            catch
            {
                clientInfo._status = ClientInfoStatus.Undefined;
                if (_onClientListChanged != null)
                {
                    _onClientListChanged(clientInfoManager.Clients);
                }
                clientSockets.Remove(client);
                client.Close();
                MessageBox.Show("Máy " + clientInfo._name + " đã thoát");
                Console.WriteLine("Đóng client");
            }

        }



        #endregion


    }
}