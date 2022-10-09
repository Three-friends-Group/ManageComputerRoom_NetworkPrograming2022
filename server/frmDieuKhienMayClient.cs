using common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class frmDieuKhienMayClient : Form
    {
        ClientInfo clientInfo;
        int w_image, h_image;
        Socket remote;

        public frmDieuKhienMayClient(ClientInfo clientInfo)
        {
            InitializeComponent();
            this.clientInfo = clientInfo;
        }

        private void listener()
        {

            try
            {
                //var IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), clientInfo._portRemote);
                //remote = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                //remote.Bind(IP);
                //Thread listen = new Thread(DoListener);
                //listen.IsBackground = true;
                //listen.Start();
                //MessageBox.Show("bat server");
                //SendMessage(clientInfo);
            }
            catch
            {

                MessageBox.Show("loi");
            }
        }

        private void DoListener()
        {
            Console.WriteLine("Log: doi may con remote ket noi");
            remote.Listen(100);
            Socket client = remote.Accept();
            MessageBox.Show("da ket noi");

            //NetworkStream netStream = new NetworkStream(clientInfo._tcpClient);
            BinaryFormatter format = new BinaryFormatter();
            Image image;
            while (true)
            {
                try
                {
                    //image = (Image)format.Deserialize(netStream);
                    //w_image = image.Width;
                    //h_image = image.Height;
                    //pictureBoxRemote.Image = image;
                    this.Refresh();
                }
                catch
                {
                    break;
                }
            }
            this.Close();
        }

        public void SendMessage(ClientInfo clientInfo)
        {
            if (clientInfo._status == ClientInfoStatus.Undefined || clientInfo._status == ClientInfoStatus.Disconnected)
            {
                MessageBox.Show("Chức năng hiện tại không khả dụng");
            }
            DataMethods dataMethod = new DataMethods(DataMethodsType.RemoteDesktop, "");
            //clientInfo._tcpClient.Send(dataMethod.Serialize());
        }

        private void pictureBoxRemote_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBoxRemote_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void frmDieuKhienMayClient_Load(object sender, EventArgs e)
        {
            listener();
        }

        private void pictureBoxRemote_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
