using common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class frmDieuKhienMayClient : Form
    {
        ClientInfo _clientInfo;
        int w_image, h_image;
        TcpListener tcpListener;
        TcpClient tcpClient, tcpClientRM;
        IPAddress svIP;
        int serverPortRM;
        Thread _thread;

        public frmDieuKhienMayClient(ClientInfo clientInfo)
        {
            InitializeComponent();
            this._clientInfo = clientInfo;
            svIP = IPAddress.Parse(clientInfo._clientIP);
            serverPortRM = 9992;
            tcpClient = clientInfo._tcpClient;
        }

        private void listener()
        {

            try
            {
                tcpListener = new TcpListener(svIP, serverPortRM);
                tcpListener.Start();
                Console.WriteLine("Log: start");
                tcpClientRM = tcpListener.AcceptTcpClient();
                Console.WriteLine("Log: start");
                _thread = new Thread(DoListener);
                Console.WriteLine("Log: start");
                _thread.Start();
            }
            catch
            {

                MessageBox.Show("loi");
            }
        }

        private void DoListener()
        {

            NetworkStream netStream = tcpClientRM.GetStream();
            BinaryFormatter format = new BinaryFormatter();
            Image image;
            while (true)
            {
                try
                {
                    image = (Image)format.Deserialize(netStream);
                    w_image = image.Width;
                    h_image = image.Height;
                    pictureBoxRemote.Image = image;
                    this.Refresh();
                }
                catch
                {
                    break;
                }
            }
            this.Close();
        }

        public void SendMessage(DataMethods dataMethod)
        {
            if (_clientInfo._status == ClientInfoStatus.Undefined || _clientInfo._status == ClientInfoStatus.Disconnected)
            {
                MessageBox.Show("Chức năng hiện tại không khả dụng");
                return;
            }
            NetworkStream netStream = tcpClient.GetStream();
            Console.WriteLine("Log: gui message");
            netStream.Write(dataMethod.Serialize(), 0, dataMethod.Serialize().Length);
            netStream.Flush();
            Console.WriteLine("Log: gui xong");
        }

        private void pictureBoxRemote_MouseClick(object sender, MouseEventArgs e)
        {

            int x = e.X * w_image / pictureBoxRemote.Width;
            int y = e.Y * h_image / pictureBoxRemote.Height;
            if (e.Button == MouseButtons.Left)
                SendMessage(new DataMethods(DataMethodsType.MouseLeftRemoteClick, x.ToString() + "|" + y.ToString()));
            if (e.Button == MouseButtons.Right)
                SendMessage(new DataMethods(DataMethodsType.MouseRightRemoteClick, x.ToString() + "|" + y.ToString()));
        }

        private void pictureBoxRemote_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x = e.X * w_image / pictureBoxRemote.Width;
            int y = e.Y * h_image / pictureBoxRemote.Height;
            if (e.Button == MouseButtons.Left)
                SendMessage(new DataMethods(DataMethodsType.MouseLeftRemoteDoubleClick, x.ToString() + "|" + y.ToString()));
            if (e.Button == MouseButtons.Right)
                SendMessage(new DataMethods(DataMethodsType.MouseRightRemoteDoubleClick, x.ToString() + "|" + y.ToString()));
        }

        private void frmDieuKhienMayClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendMessage(new DataMethods(DataMethodsType.KeyRemotePress, (int)e.KeyChar));

        }

        private void pictureBoxRemote_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X * w_image / pictureBoxRemote.Width;
            int y = e.Y * h_image / pictureBoxRemote.Height;
            SendMessage(new DataMethods(DataMethodsType.MouseRemoteMove, x.ToString() + "|" + y.ToString()));
        }

        private void frmDieuKhienMayClient_Load(object sender, EventArgs e)
        {
            SendMessage(new DataMethods(DataMethodsType.RemoteDesktop, ""));
            listener();
        }

    }
}
