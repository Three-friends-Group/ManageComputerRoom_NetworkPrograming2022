using common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class UfrmClient : UserControl
    {

        public ClientInfo _clientInfo { get; private set; }
        public UfrmClient(ClientInfo clientInfo)
        {
            InitializeComponent();
            _clientInfo = new ClientInfo(clientInfo);
            SetContent(_clientInfo);
        }


        #region methods
        public void SetContent(ClientInfo clientInfo)
        {
            _clientInfo._status = clientInfo._status;
            if (!string.IsNullOrWhiteSpace(clientInfo._name))
            {
                lblName.Text = clientInfo._name;
            }
            else
            {
                lblName.Text = "N/A";
            }

            if (!string.IsNullOrWhiteSpace(clientInfo._clientIP))
            {
                lblIP.Text = clientInfo._clientIP + ":" + clientInfo._port;
            }
            else
            {
                lblIP.Text = "No IP";
            }


            string imageName = "";
            switch (clientInfo._status)
            {
                case ClientInfoStatus.Undefined:
                    {
                        imageName = "undefined_computer.png";
                        break;
                    }
                case ClientInfoStatus.Connected:
                    {
                        imageName = "active_computer.png";
                        break;
                    }

                case ClientInfoStatus.Disconnected:
                    {
                        imageName = "inactive_computer.png";
                        break;
                    }




            }
            Bitmap bitmap = new Bitmap(Common.PathUtils.GetPathTo("Assets", imageName));
            pbStatus.Image = bitmap;



        }
        #endregion


        /// <summary>
        /// chat với client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chatClient_on_click(object sender, EventArgs e)
        {

            MessageBox.Show(_clientInfo._name + _clientInfo._clientIP + _clientInfo._port + _clientInfo._status);
            if (CheckClientConnected())
            {
                var form_TroChuyen = new frmChatOne(_clientInfo);
                form_TroChuyen.Show();
            }
            else
            {
                return;
            }
        }

        private bool CheckClientConnected()
        {
            if (_clientInfo._status == ClientInfoStatus.Undefined || _clientInfo._status == ClientInfoStatus.Disconnected)
            {
                MessageBox.Show("Chức năng hiện tại không khả dụng: " + _clientInfo._status);
                return false;
            }
            return true;
        }
        /// <summary>
        /// điều khiển
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void directClient_on_click(object sender, EventArgs e)
        {

            var form_DieuKhien = new frmDieuKhienMayClient();
            form_DieuKhien.Show();
        }

        private void UfrmClient_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
            MessageBox.Show(_clientInfo._name + _clientInfo._clientIP + _clientInfo._port);
        }

        private void UfrmClient_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
            MessageBox.Show(_clientInfo._name + _clientInfo._clientIP + _clientInfo._port);
        }


        #region methods
        #endregion
    }
}
