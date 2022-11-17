using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class ClientInfoManager
    {

        private readonly List<ClientInfo> _clients;
        private readonly List<ClientInfo> _clientsOnline;


        public List<ClientInfo> Clients
        {
            get
            {
                return new List<ClientInfo>(_clients);
            }
        }
        public List<ClientInfo> ClientsOnline
        {
            get
            {
                return new List<ClientInfo>(_clientsOnline);
            }
        }
        public ClientInfoManager()
        {
            _clients = new List<ClientInfo>();
            _clientsOnline = new List<ClientInfo>();
        }

        public void xuat()
        {
            foreach (ClientInfo client in _clients)
            {
                Console.WriteLine("Log: tung client la" + client);
            }
            foreach (ClientInfo client in _clientsOnline)
            {
                Console.WriteLine("Log: tung client la" + client);
            }
        }
        public void AddRange(string firstIP, string lastIP, string subnetMask)
        {
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

        public int? IndexOf(ClientInfo clientInfo, List<ClientInfo> clients)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (clients[i]._clientIP.Equals(clientInfo._clientIP) && clients[i]._port.Equals(clientInfo._port))
                {
                    return i;
                }
            }
            return null;
        }
        public int? RemoveClientsOnline(ClientInfo clientInfo)
        {
            int? index = IndexOf(clientInfo, _clientsOnline);
            if (index != null)
            {
                _clientsOnline.RemoveAt((int)index);
                return 1;
            }
            return 0;
        }

        public int? IndexOf(string ipAddress, List<ClientInfo> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i]._clientIP.Equals(ipAddress))
                {
                    return i;
                }
            }
            return null;
        }
        public void AddTail(ClientInfo client)
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
            int? index = IndexOf(clientInfo, _clients);
            if (index != null)
            {
                Console.WriteLine("Log: add");
                _clients[(int)index] = clientInfo;
            }
        }
        public void AddTailOnline(ClientInfo clientInfo)
        {
            _clientsOnline.Add(clientInfo);
        }
        public void AddOnline(ClientInfo clientInfo)
        {
            int? index = IndexOf(clientInfo, _clientsOnline);
            if (index != null && clientInfo._status == ClientInfoStatus.Connected)
            {
                Console.WriteLine("Log: add");
                _clientsOnline[(int)index] = clientInfo;
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
