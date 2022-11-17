using common;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
            _clientInfo = clientInfo;
            _clientInfo._isLockScreen = false;
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
            Console.WriteLine("Log: " + clientInfo._clientIP);

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


        private bool CheckClientConnected()
        {
            if (_clientInfo._status == ClientInfoStatus.Undefined || _clientInfo._status == ClientInfoStatus.Disconnected)
            {
                MessageBox.Show("Chức năng hiện tại không khả dụng: " + _clientInfo._status);
                return false;
            }
            return true;
        }
        #endregion


        #region handleEvent

        /// <summary>
        /// điều khiển
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void directClient_on_click(object sender, EventArgs e)
        {
            if (CheckClientConnected())
            {
                var form_DieuKhien = new frmDieuKhienMayClient(_clientInfo);
                form_DieuKhien.ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void UfrmClient_Click(object sender, EventArgs e)
        {
        }

        private void UfrmClient_DoubleClick(object sender, EventArgs e)
        {
        }

        #endregion

        private void lockMouseAndKeyboardClient_Click(object sender, EventArgs e)
        {
            SendMessage(new DataMethods(DataMethodsType.LockMouseAndKeyBoard, ""));
        }

        private void restartClient_Click(object sender, EventArgs e)
        {

            //MessageBox.Show();
            var frm_set_time = new frmSetTime();

            DialogResult result = frm_set_time.ShowDialog();
            if (result != DialogResult.OK) return;
            int timeDelay = common.Uitls.SetTimeDelay(frm_set_time.timeDelay);
            SendMessage(new DataMethods(DataMethodsType.Restart, timeDelay.ToString()));
        }

        private void shutDownClient_Click(object sender, EventArgs e)
        {
            var frm_set_time = new frmSetTime();

            DialogResult result = frm_set_time.ShowDialog();
            if (result != DialogResult.OK) return;
            int timeDelay = common.Uitls.SetTimeDelay(frm_set_time.timeDelay);
            SendMessage(new DataMethods(DataMethodsType.Shutdown, timeDelay.ToString()));
        }

        private void SendMessage(DataMethods dataMethod)
        {
            if (_clientInfo._status == ClientInfoStatus.Undefined || _clientInfo._status == ClientInfoStatus.Disconnected)
            {
                MessageBox.Show("Chức năng hiện tại không khả dụng");
                return;
            }
            NetworkStream netStream = _clientInfo._tcpClient.GetStream();
            Console.WriteLine("Log: gui message");
            netStream.Write(dataMethod.Serialize(), 0, dataMethod.Serialize().Length);
            netStream.Flush();
            Console.WriteLine("Log: gui xong");
        }

        private void lockScreen_Click(object sender, EventArgs e)
        {
            if (_clientInfo._isLockScreen)
            {
                lockScreen.Text = "Khóa màn hình";
                SendMessage(new DataMethods(DataMethodsType.UnlockScreen, ""));
                _clientInfo._isLockScreen = false;
            }
            else
            {
                lockScreen.Text = "Mở khóa màn hình";
                SendMessage(new DataMethods(DataMethodsType.LockScreen, ""));
                _clientInfo._isLockScreen = true;
            }

        }
    }
}
