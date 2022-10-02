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

    public enum ClientInfoStatus
    {
        Undefined,
        Connected,
        Disconnected
    }
    public class ClientInfo
    {
        public string Name { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public string ClientIP { get; set; }
        public ClientInfoStatus Status { get; set; }

        public ClientInfo()
        {
            EndPoint = new IPEndPoint(IPAddress.Any, 0);
            Status = ClientInfoStatus.Undefined;
        }

        public ClientInfo(string name, string ip, ClientInfoStatus status)
        {
            this.Name = name;
            this.EndPoint = new IPEndPoint(IPAddress.Parse(ip), 0);
            this.Status = status;

        }
        public ClientInfo(ClientInfo client)
        {
            this.Name = client.Name;
            this.EndPoint = client.EndPoint;
            this.Status = client.Status;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            ClientInfo client = obj as ClientInfo;
            return client.ClientIP == ClientIP && client.Name == Name && client.Status == Status;
        }
    }
}
