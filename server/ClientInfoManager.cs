using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class ClientInfoManager
    {
        private const string DEFAULT_IP = "0.0.0.0";

        private readonly List<ClientInfo> _clients;
        private bool _generateByNumberOfClients;


        public List<ClientInfo> Clients
        {
            get
            {
                return new List<ClientInfo>(_clients);
            }
        }
        public ClientInfoManager()
        {
            _generateByNumberOfClients = false;
            _clients = new List<ClientInfo>();
        }

        public void xuat()
        {
            foreach (ClientInfo client in _clients)
            {
                Console.WriteLine("Log: tung client la" + client);
            }
        }
        public ClientInfoManager(string firstIP, string lastIP, string subnetMask)
        {
            _generateByNumberOfClients = false;
            _clients = new List<ClientInfo>();
            try
            {
                string s1 = "", s2 = "";
                int y = 0, x = 0, z = 0, t = 0;
                if (firstIP != "")
                {
                    s1 = firstIP.Substring(0, firstIP.LastIndexOf("."));
                    x = int.Parse(firstIP.Substring(firstIP.LastIndexOf(".") + 1));
                }

                if (lastIP != "")
                {
                    s2 = lastIP.Substring(0, lastIP.LastIndexOf("."));
                    y = int.Parse(lastIP.Substring(lastIP.LastIndexOf(".") + 1));
                }

                t = y - x;
                if (subnetMask != "")
                    z = 256 - int.Parse(subnetMask.Substring(subnetMask.LastIndexOf(".") + 1));

                if (x < 255 && y < 255 && s1.CompareTo(s2) == 0)
                {
                    for (int i = x; i < z && i <= y; i++)
                    {
                        string ip = s1 + "." + i.ToString();

                        ClientInfo clientInfo = new ClientInfo();
                        clientInfo._clientIP = ip;
                        _clients.Add(clientInfo);
                    }
                }
                else
                {
                    throw new Exception("Thông tin dãy IP của máy con không hợp lệ");
                }
            }
            catch
            {
                throw new Exception("Thông tin dãy IP của máy con không hợp lệ");
            }
        }

        public ClientInfoManager(int numberOfClients)
        {
            _generateByNumberOfClients = true;
            _clients = new List<ClientInfo>();
            for (int i = 0; i < numberOfClients; i++)
            {
                ClientInfo clientInfo = new ClientInfo();
                clientInfo._clientIP = DEFAULT_IP;
                _clients.Add(clientInfo);
            }
        }
        public int? IndexOf(ClientInfo clientInfo)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i]._clientIP.Equals(clientInfo._clientIP) && _clients[i]._port.Equals(clientInfo._port))
                {
                    return i;
                }
            }
            return null;
        }

        public int? IndexOf(string ipAddress)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i]._clientIP.Equals(ipAddress))
                {
                    return i;
                }
            }
            return null;
        }
        void AddNewClient_GenerateByNumberOfClients(ClientInfo client)
        {
            int i = 0;
            while (true)
            {
                if (_clients[i]._clientIP.Equals(client._clientIP) && _clients[i]._port.Equals(client._port)) break;
                i++;
            }

            _clients[i] = client;
        }

        void AddTail(ClientInfo client)
        {
            _clients.Add(client);
        }

        public ClientInfo Find(ClientInfo client)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i]._clientIP.Equals(client._clientIP) && _clients[i]._port.Equals(client._port))
                    return _clients[i];
            }

            return null;
        }

        public ClientInfo Find(string ipAddress)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i]._clientIP.Equals(ipAddress))
                    return _clients[i];
            }
            return null;
        }
        public ClientInfo FindByIdAndPort(string ipAddress, string port)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i]._clientIP.Equals(ipAddress) && _clients[i]._port.Equals(port))
                    return _clients[i];
            }
            return null;
        }

        public void Add(ClientInfo clientInfo)
        {
            int? index = IndexOf(clientInfo);
            if (index != null)
            {
                _clients[(int)index] = clientInfo;
            }

            if (_generateByNumberOfClients)
            {
                AddNewClient_GenerateByNumberOfClients(clientInfo);

            }
            else
            {
                AddTail(clientInfo);
            }
        }

        public void DisconnectAll()
        {
            foreach (ClientInfo item in _clients)
            {
                if (item._status != ClientInfoStatus.Undefined)
                    item._status = ClientInfoStatus.Disconnected;
            }
        }

        public List<ClientInfo> GetEmptyClients()
        {
            List<ClientInfo> result = new List<ClientInfo>();
            foreach (ClientInfo item in _clients)
            {
                if (item._status == ClientInfoStatus.Connected)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
