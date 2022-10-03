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

        ServerProgram serverProgram;

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            serverProgram = new ServerProgram();
            serverProgram.OnClientListChanged += ServerProgram_OnClientListChanged;
            //serverProgram.OnServerStarted += HandleOnServerStarted;

            serverProgram.Connect();

        }

        private void ServerProgram_OnClientListChanged(List<ClientInfo> clients)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderClientList(clients);
                });
            }
            else
            {
                RenderClientList(clients);
            }
        }



        #region methods


        void RenderClientList(List<ClientInfo> clients)
        {
            if (flpMain.Controls.Count == 0)
            {
                foreach (ClientInfo clientInfo in clients)
                {
                    UfrmClient frm = new UfrmClient(clientInfo);
                    flpMain.Controls.Add(frm);
                }

                return;
            }

            int clientControlLength = flpMain.Controls.Count;
            int i = 0;
            for (i = 0; i < clients.Count; i++)
            {
                ClientInfo clientInfoInList = clients[i];

                if (i < clientControlLength)
                {
                    UfrmClient frm = flpMain.Controls[i] as UfrmClient;
                    frm.SetContent(clientInfoInList);
                }
                else
                {
                    UfrmClient frm = new UfrmClient(clientInfoInList);
                    flpMain.Controls.Add(frm);
                }
            }

            if (i < flpMain.Controls.Count)
                for (int j = flpMain.Controls.Count - 1; j >= i; j--)
                    flpMain.Controls.RemoveAt(j);
        }


        #endregion

        #region events
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

        #endregion
    }
}
