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

        IPAddress IP;
        TcpListener server;
        TcpClient client;
        ClientInfo _clientInfo;


        List<TcpClient> tcpClients;
        Thread _thread;

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
            _thread = new Thread(Connect);
            _thread.Start();

            tcpClients = new List<TcpClient>();
            clientInfoManager = new ClientInfoManager();
        }


        #region Methods

        /// <summary>
        /// hàm tạo connect server 
        /// </summary>
        public void Connect()
        {
            try
            {
                IP = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(IP, PORT);
                server.Start();
                while (true)
                {
                    client = server.AcceptTcpClient();
                    tcpClients.Add(client);


                    string[] endpoint = client.Client.RemoteEndPoint.ToString().Split(':');
                    MessageBox.Show(endpoint[0].ToString());
                    string clientIP = endpoint[0];
                    string clientPort = endpoint[1];
                    ClientInfo clientInfo = clientInfoManager.FindByIdAndPort(clientIP, clientPort);
                    if (clientInfo == null)
                    {
                        _clientInfo = new ClientInfo(client);
                        _clientInfo._port = clientPort;
                        _clientInfo._endpoint = client.Client.RemoteEndPoint as IPEndPoint;
                        _clientInfo._clientIP = clientIP;
                        Console.WriteLine("Log trong server" + _clientInfo._clientIP);
                        Console.WriteLine("Log trong server" + _clientInfo._port);
                        _clientInfo._status = ClientInfoStatus.Connected;
                        clientInfoManager.Add(_clientInfo);
                    }
                    else
                    {
                        _clientInfo = clientInfo;
                    }

                    //luồng lắng nghe tin nhắn và lệnh
                    _clientInfo._thread = new Thread(listener);
                    _clientInfo._thread.IsBackground = true;
                    _clientInfo._thread.Start();
                    clientInfoManager.xuat();
                    if (_onClientListChanged != null)
                    {
                        _onClientListChanged(clientInfoManager.Clients);
                    }
                }
            }
            catch
            {
                int error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                if (error != 10004)
                {
                    MessageBox.Show("Lỗi khởi tạo Server!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// lắng nghe kết nối từ client
        /// </summary>
        public void listener()
        {
            TcpClient tcpClient = client;
            NetworkStream netStream = tcpClient.GetStream();
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    netStream.Read(buffer, 0, client.ReceiveBufferSize);
                    DataMethods dataMethods = (DataMethods)DataMethods.Deserialize(buffer);
                    switch (dataMethods.Type)
                    {
                        case DataMethodsType.SendName:
                            {
                                _clientInfo._name = dataMethods.Data as String;
                                break;
                            }
                        default:
                            break;
                    }

                }
                catch
                {
                    _clientInfo._thread.Abort();
                }

            }
        }

        #endregion


    }
}