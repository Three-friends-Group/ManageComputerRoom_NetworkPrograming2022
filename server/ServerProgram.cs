using common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server
{
    public class ServerProgram
    {
        private const int PORT = 9999;
        private const int BUFFER_SIZE = 1024 * 5000;

        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        ClientInfoManager clientInfoManager;

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
            clientList = new List<Socket>();
            clientInfoManager = new ClientInfoManager();
            Connect();
        }


        #region Methods
        event Action<List<ClientInfo>> _onClientListChanged;
        public event Action<List<ClientInfo>> OnClientListChanged
        {
            add { _onClientListChanged += value; }
            remove { _onClientListChanged -= value; }
        }

        event Action<IPEndPoint> _onServerStarted;
        public event Action<IPEndPoint> OnServerStarted
        {
            add { _onServerStarted += value; }
            remove { _onServerStarted -= value; }
        }

        /// <summary>
        /// hàm tạo connect server 
        /// </summary>
        public void Connect()
        {
            IP = new IPEndPoint(IPAddress.Any, PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            server.Bind(IP);
            Thread listen = new Thread(StartAceptClient);
            listen.IsBackground = true;
            listen.Start();
        }

        /// <summary>
        /// lắng nghe kết nối từ client
        /// </summary>
        public void StartAceptClient()
        {
            if (!server.Connected)
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        Thread listenClient = new Thread(Receive);
                        listenClient.IsBackground = true;
                        listenClient.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, PORT);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            }
        }


        /// <summary>
        /// ngắt kết nối
        /// </summary>
        public void Close()
        {
            server.Close();
        }

        public void Receive(object obj)
        {
            Socket client = obj as Socket;
            string clientIP = client.RemoteEndPoint.ToString().Split(':')[0];
            ClientInfo clientInfo = clientInfoManager.Find(clientIP);
            try
            {
                while (true)
                {
                    byte[] data = new byte[BUFFER_SIZE];
                    client.Receive(data);
                    string message = (string)DataMethods.Deserialize(data);
                    //DataMethods dataContainer = DataMethods
                }

            }
            catch
            {

            }

        }
        #endregion


    }
}