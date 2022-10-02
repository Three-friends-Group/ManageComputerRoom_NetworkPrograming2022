using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class frmMain : Form
    {
        List<ClientInfo> clientList = new List<ClientInfo>();

        public frmMain()
        {
            InitializeComponent();
            ClientInfo client1 = new ClientInfo("Long", "127.0.0.4", ClientInfoStatus.Connected);
            ClientInfo client2 = new ClientInfo("Duật", "127.0.0.6", ClientInfoStatus.Disconnected);

            ClientInfo client3 = new ClientInfo("Hưng", "127.0.0.7", ClientInfoStatus.Undefined);
            ClientInfo client4 = new ClientInfo("Long", "127.0.0.4", ClientInfoStatus.Connected);
            ClientInfo client5 = new ClientInfo("Duật", "127.0.0.6", ClientInfoStatus.Disconnected);

            ClientInfo client6 = new ClientInfo("Hưng", "127.0.0.7", ClientInfoStatus.Undefined);
            ClientInfo client7 = new ClientInfo("Long", "127.0.0.4", ClientInfoStatus.Connected);
            ClientInfo client8 = new ClientInfo("Duật", "127.0.0.6", ClientInfoStatus.Disconnected);

            ClientInfo client9 = new ClientInfo("Hưng", "127.0.0.7", ClientInfoStatus.Undefined);
            ClientInfo client10 = new ClientInfo("Long", "127.0.0.4", ClientInfoStatus.Connected);
            ClientInfo client11 = new ClientInfo("Duật", "127.0.0.6", ClientInfoStatus.Disconnected);

            ClientInfo client12 = new ClientInfo("Hưng", "127.0.0.7", ClientInfoStatus.Undefined);
            clientList.Add(client1);
            clientList.Add(client2);
            clientList.Add(client3);
            clientList.Add(client4);
            clientList.Add(client5);
            clientList.Add(client6);
            clientList.Add(client7);
            clientList.Add(client8);
            clientList.Add(client9);
            clientList.Add(client10);
            clientList.Add(client11);
            clientList.Add(client12);
            if (flpMain.Controls.Count == 0)
            {
                foreach (ClientInfo clientInfo in clientList)
                {
                    UfrmClient frm = new UfrmClient(clientInfo);
                    flpMain.Controls.Add(frm);
                }
                return;
            }
        }


        // mở form cấu hình
        private void btnCauHinh_SV_Click(object sender, EventArgs e)
        {
            var form_CauHinh = new frmCauHinh_SV();
            form_CauHinh.Show();
        }

        // mở form gửi tin nhắn gửi tất cả qua nút click button
        private void btnGuiTinNhanAll_SV_Click(object sender, EventArgs e)
        {
            //var form_GuiTinNhanAll = new frmGuiTinNhanTatCaClinet();
            //form_GuiTinNhanAll.Show();
        }

        // thoát chương trình
        private void btnThoat_SV_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnKhoiDongLai_SV_Click(object sender, EventArgs e)
        {

        }
    }
}
