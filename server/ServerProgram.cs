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
        TcpClient clientTcp;
        ClientInfo clientInfo;


        List<TcpClient> tcpClients;
        Thread _thread;

        public ClientInfoManager clientInfoManager;
        private event Action<List<ClientInfo>> _onClientListChanged;
        public event Action<List<ClientInfo>> OnClientListChanged
        {
            add { _onClientListChanged += value; }
            remove { _onClientListChanged -= value; }
        }


        private event Action<String> _onRecieveMessageFromClient;
        public event Action<String> OnRecieveMessageFromClient
        {
            add { _onRecieveMessageFromClient += value; }
            remove { _onRecieveMessageFromClient -= value; }
        }
        private event Action<List<ClientInfo>> _onClientOnlineListChanged;
        public event Action<List<ClientInfo>> OnClientOnlineListChanged
        {
            add { _onClientOnlineListChanged += value; }
            remove { _onClientOnlineListChanged -= value; }
        }

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
                    clientTcp = server.AcceptTcpClient();
                    tcpClients.Add(clientTcp);
                    string[] endpoint = clientTcp.Client.RemoteEndPoint.ToString().Split(':');
                    string clientIP = endpoint[0];
                    string clientPort = endpoint[1];
                    clientInfo = clientInfoManager.FindByIdAndPort(clientIP, clientPort);
                    if (clientInfo == null)
                    {
                        clientInfo = new ClientInfo(clientTcp);
                        clientInfo._port = clientPort;
                        clientInfo._endpoint = clientTcp.Client.RemoteEndPoint as IPEndPoint;
                        clientInfo._clientIP = clientIP;
                        clientInfo._status = ClientInfoStatus.Connected;
                        clientInfoManager.AddTail(clientInfo);
                        clientInfoManager.AddTailOnline(clientInfo);
                        clientInfoManager.xuat();
                    }
                    else
                    {
                        clientInfo._tcpClient = clientTcp;
                        clientInfo._status = ClientInfoStatus.Connected;
                        //clientInfoManager.AddOnline(clientInfo);
                        clientInfoManager.AddTailOnline(clientInfo);
                    }

                    //luồng lắng nghe tin nhắn và lệnh
                    clientInfo._thread = new Thread(listener);
                    clientInfo._thread.IsBackground = true;
                    clientInfo._thread.Start();
                    clientInfoManager.xuat();
                    if (_onClientListChanged != null)
                    {
                        _onClientListChanged(clientInfoManager.Clients);
                    }
                    if (_onClientOnlineListChanged != null)
                    {
                        _onClientOnlineListChanged(clientInfoManager.ClientsOnline);
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
                clientTcp.Close();
                server.Stop();
            }
        }

        /// <summary>
        /// lắng nghe kết nối từ client
        /// </summary>
        public void listener()
        {
            TcpClient tcpClient = clientTcp;
            NetworkStream netStream = tcpClient.GetStream();
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[clientTcp.ReceiveBufferSize];
                    netStream.Read(buffer, 0, clientTcp.ReceiveBufferSize);
                    DataMethods dataMethods = (DataMethods)DataMethods.Deserialize(buffer);
                    switch (dataMethods.Type)
                    {
                        case DataMethodsType.SendName:
                            {
                                clientInfo._name = dataMethods.Data as String;
                                if (_onClientListChanged != null)
                                {
                                    _onClientListChanged(clientInfoManager.Clients);
                                }
                                break;
                            }
                        case DataMethodsType.SendMessageToServer:
                            {
                                if (_onRecieveMessageFromClient != null)
                                {
                                    _onRecieveMessageFromClient(dataMethods.Data as String);
                                }
                                break;
                            }
                        default:
                            break;
                    }

                }
                catch
                {

                    clientInfo._status = ClientInfoStatus.Undefined;
                    clientInfoManager.RemoveClientsOnline(clientInfo);
                    if (_onClientListChanged != null)
                    {
                        _onClientListChanged(clientInfoManager.Clients);

                    }
                    if (_onClientOnlineListChanged != null)
                    {
                        _onClientOnlineListChanged(clientInfoManager.ClientsOnline);
                    }
                    clientTcp.Close();
                    Console.WriteLine("Đóng client");
                    clientInfo._thread.Abort();
                    clientTcp.Close();
                }

            }

        }
        public void SetClientInfoList(string FirstIP, string LastIP, string SubnetMask)
        {
            clientInfoManager.AddRange(FirstIP, LastIP, SubnetMask);

            if (_onClientListChanged != null)
                _onClientListChanged(clientInfoManager.Clients);
            if (_onClientOnlineListChanged != null)
                _onClientOnlineListChanged(clientInfoManager.ClientsOnline);
        }

        public void Disconnect()
        {
            SendMessage(new DataMethods(DataMethodsType.Exit, ""), clientInfo);
            clientTcp.Close();
            server.Stop();
        }



        public void SendMessage(DataMethods dataMethod, ClientInfo clientInfo)
        {
            try
            {
                NetworkStream netStream = clientInfo._tcpClient.GetStream(); Console.WriteLine("Log: gui message");
                netStream.Write(dataMethod.Serialize(), 0, dataMethod.Serialize().Length);
                netStream.Flush();
                Console.WriteLine("Log: gui xong");
            }
            catch
            {

            }
        }
        public void SendMessageAll(DataMethods dataMethod)
        {
            foreach (ClientInfo clientInfo in clientInfoManager.ClientsOnline)
            {
                SendMessage(dataMethod, clientInfo);
            }
        }

        public void chatAll(string message)
        {
            SendMessageAll(new DataMethods(DataMethodsType.SendMessageToAll, message));
        }

        public void lockScreenAll()
        {
            foreach (ClientInfo clientInfo in clientInfoManager.ClientsOnline)
            {
                if (clientInfo._isLockScreen)
                {
                    SendMessage(new DataMethods(DataMethodsType.UnlockScreen, ""), clientInfo);
                    clientInfo._isLockScreen = false;
                }
                else
                {
                    SendMessage(new DataMethods(DataMethodsType.LockScreen, ""), clientInfo);
                    clientInfo._isLockScreen = true;
                }
            }

        }

    }


    #endregion


}