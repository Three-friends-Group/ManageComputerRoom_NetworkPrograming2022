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
        public string _name { get; set; }
        public IPEndPoint _endpoint { get; set; }
        public string _clientIP { get; set; }
        public string _port { get; set; }
        public ClientInfoStatus _status { get; set; }
        public Socket _socket { get; set; }
        public Thread _thread { get; set; }

        public ClientInfo()
        {
            _endpoint = new IPEndPoint(IPAddress.Any, 0);
            _status = ClientInfoStatus.Undefined;
        }

        public ClientInfo(string name, string ip, ClientInfoStatus status, string port, Socket client, Thread thread)
        {
            this._name = name;
            this._clientIP = ip;
            this._endpoint = new IPEndPoint(IPAddress.Parse(ip), 0);
            this._status = status;
            this._port = port;
            this._socket = client;
            this._thread = thread;
        }

        public override string ToString()
        {
            return _name + "\t" + _endpoint + "\t" + _clientIP + "\t" + _status;
        }
        public ClientInfo(ClientInfo client)
        {
            this._name = client._name;
            this._endpoint = client._endpoint;
            this._status = client._status;
            this._clientIP = client._clientIP;
            this._port = client._port;
            this._socket = client._socket;
            this._thread = client._thread;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            ClientInfo client = obj as ClientInfo;
            return client._clientIP == _clientIP && client._name == _name && client._status == _status;
        }
    }
}
