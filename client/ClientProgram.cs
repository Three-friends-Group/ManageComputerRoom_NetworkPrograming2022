using common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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
        private const int PORT = 9999;

        IPEndPoint IP;
        Socket client;

        public void Connect(string hostname, int port)
        {
            IP = new IPEndPoint(IPAddress.Parse(hostname), port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            string computerName = System.Environment.MachineName;

            try
            {

                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối server", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }


        public void Close()
        {
            client.Close();
        }
        public void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)DataMethods.Deserialize(data);
                }
            }
            catch
            {
                Close();
            }

        }
    }
}
