using common;
using server.Properties;
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
                Console.WriteLine("Log: start0");
                tcpListener = new TcpListener(IPAddress.Any, serverPortRM);
                Console.WriteLine("Log: start1");
                tcpListener.Start();
                Console.WriteLine("Log: start2");
                tcpClientRM = tcpListener.AcceptTcpClient();
                Console.WriteLine("Log: start3");
                _thread = new Thread(DoListener);
                _thread.IsBackground = true;
                Console.WriteLine("Log: start4");
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

        public void SafeSendValue(DataMethods dataMethod)
        {
            if (_clientInfo._status == ClientInfoStatus.Undefined || _clientInfo._status == ClientInfoStatus.Disconnected)
            {
                MessageBox.Show("Chức năng hiện tại không khả dụng");
                return;
            }
            NetworkStream netStream = tcpClientRM.GetStream();
            netStream.Write(dataMethod.Serialize(), 0, dataMethod.Serialize().Length);
            netStream.Flush();
        }




        /// <summary>
        /// xu ly chuot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxRemote_MouseClick(object sender, MouseEventArgs e)
        {

            int x = e.X * w_image / pictureBoxRemote.Width;
            int y = e.Y * h_image / pictureBoxRemote.Height;
            if (e.Button == MouseButtons.Left)
                //SafeSendValue(new DataMethods(DataMethodsType.MouseLeftRemoteClick, x.ToString() + "|" + y.ToString()));
                SafeSendValue(new DataMethods(DataMethodsType.LCLICK, ""));
            else if (e.Button == MouseButtons.Right)
                //SafeSendValue(new DataMethods(DataMethodsType.MouseRightRemoteClick, x.ToString() + "|" + y.ToString()));
                SafeSendValue(new DataMethods(DataMethodsType.RCLICK, ""));
        }
        private void pictureBoxRemote_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                //SafeSendValue(new DataMethods(DataMethodsType.MouseLeftRemoteClick, x.ToString() + "|" + y.ToString()));
                SafeSendValue(new DataMethods(DataMethodsType.LDOWN, ""));
            else if (e.Button == MouseButtons.Right)
                //SafeSendValue(new DataMethods(DataMethodsType.MouseRightRemoteClick, x.ToString() + "|" + y.ToString()));
                SafeSendValue(new DataMethods(DataMethodsType.RDOWN, ""));

        }

        private void pictureBoxRemote_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                //SafeSendValue(new DataMethods(DataMethodsType.MouseLeftRemoteClick, x.ToString() + "|" + y.ToString()));
                SafeSendValue(new DataMethods(DataMethodsType.LUP, ""));
            else if (e.Button == MouseButtons.Right)
                //SafeSendValue(new DataMethods(DataMethodsType.MouseRightRemoteClick, x.ToString() + "|" + y.ToString()));
                SafeSendValue(new DataMethods(DataMethodsType.RUP, ""));
        }
        private void pictureBoxRemote_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X * w_image / pictureBoxRemote.Width;
            int y = e.Y * h_image / pictureBoxRemote.Height;
            SafeSendValue(new DataMethods(DataMethodsType.MOVE, x.ToString() + "|" + y.ToString()));
        }

        private void pictureBoxRemote_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x = e.X * w_image / pictureBoxRemote.Width;
            int y = e.Y * h_image / pictureBoxRemote.Height;
            if (e.Button == MouseButtons.Left)
                SafeSendValue(new DataMethods(DataMethodsType.LDCLICK, x.ToString() + "|" + y.ToString()));
            if (e.Button == MouseButtons.Right)
                SafeSendValue(new DataMethods(DataMethodsType.RDCLICK, x.ToString() + "|" + y.ToString()));
            //SafeSendValue(new DataMethods(DataMethodsType.MouseRightRemoteClick, ""));
        }


        private void frmDieuKhienMayClient_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Console.WriteLine("Log: key la: " + e.KeyChar); ////Console.WriteLine("Log: ma key la: " + (int)e.KeyChar);
            //SafeSendValue(new DataMethods(DataMethodsType.KEYPRESS, (int)e.KeyChar));
        }


        //private void frmDieuKhienMayClient_KeyUp(object sender, KeyEventArgs e)
        //{
        //    SafeSendValue(new DataMethods(DataMethodsType.KEYUP, (int)e.KeyCode));
        //}

        private void frmDieuKhienMayClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendMessage(new DataMethods(DataMethodsType.ExitRemote, ""));
            tcpClientRM.Close();
            tcpListener.Stop();

        }


        private void frmDieuKhienMayClient_Load(object sender, EventArgs e)
        {
            SendMessage(new DataMethods(DataMethodsType.RemoteDesktop, ""));
            listener();
        }

    }
}
