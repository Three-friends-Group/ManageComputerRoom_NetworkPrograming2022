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

        public ClientInfo ClientInfo { get; private set; }
        public UfrmClient(ClientInfo clientInfo)
        {
            InitializeComponent();
            ClientInfo = new ClientInfo(clientInfo);
            SetContent(clientInfo);
        }


        #region methods
        private void SetContent(ClientInfo clientInfo)
        {
            if (!string.IsNullOrWhiteSpace(clientInfo.Name))
            {
                lblName.Text = clientInfo.Name;
            }
            else
            {
                lblName.Text = "N/A";
            }

            if (!string.IsNullOrWhiteSpace(clientInfo.ClientIP))
            {
                lblIP.Text = clientInfo.ClientIP;
            }
            else
            {
                lblIP.Text = "No IP";
            }


            string imageName = "";
            switch (clientInfo.Status)
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
            //var form_TroChuyen = new frmTroChuyen();
            //form_TroChuyen.Show();
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
    }
}
