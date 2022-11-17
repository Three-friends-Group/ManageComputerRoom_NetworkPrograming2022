using common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
            serverProgram.OnClientOnlineListChanged += ServerProgram_OnClientOnlineListChanged;
            //serverProgram.OnServerStarted += HandleOnServerStarted;
        }

        private void ServerProgram_OnClientOnlineListChanged(List<ClientInfo> clientsOnline)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderAmountOfClientsOnline(clientsOnline);
                });
            }
            else
            {
                RenderAmountOfClientsOnline(clientsOnline);
            }
        }

        private void ServerProgram_OnClientListChanged(List<ClientInfo> clients)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderAmountOfClients(clients);
                    RenderClientList(clients);
                });
            }
            else
            {
                RenderAmountOfClients(clients);
                RenderClientList(clients);
            }
        }



        #region methods

        void RenderAmountOfClients(List<ClientInfo> clients)
        {
            lblSLMay.Text = clients.Count.ToString();
        }
        void RenderAmountOfClientsOnline(List<ClientInfo> clients)
        {
            lblSLOnline.Text = clients.Count.ToString();
        }

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


        // thoát chương trình
        private void btnThoat_SV_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnKhoiDongLai_SV_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void tool_RestartAll_Click(object sender, EventArgs e)
        {
            var frm_set_time = new frmSetTime();

            DialogResult result = frm_set_time.ShowDialog();
            if (result != DialogResult.OK) return;
            int timeDelay = common.Uitls.SetTimeDelay(frm_set_time.timeDelay);
            serverProgram.SendMessageAll(new DataMethods(DataMethodsType.Restart, timeDelay.ToString()));
        }

        private void tool_shutDown_All_Click(object sender, EventArgs e)
        {
            //MessageBox.Show();
            var frm_set_time = new frmSetTime();

            DialogResult result = frm_set_time.ShowDialog();
            if (result != DialogResult.OK) return;
            int timeDelay = common.Uitls.SetTimeDelay(frm_set_time.timeDelay);
            serverProgram.SendMessageAll(new DataMethods(DataMethodsType.Shutdown, timeDelay.ToString()));
        }

        private void tool_lockAll_Click(object sender, EventArgs e)
        {
            serverProgram.lockScreenAll();
        }

        private void toolThoat_SV_Click(object sender, EventArgs e)
        {
            serverProgram.Disconnect();
            Application.Exit();
        }

        private void tool_cauHinhSV_Click(object sender, EventArgs e)
        {
            var form_CauHinh = new frmCauHinh_SV();
            DialogResult result = form_CauHinh.ShowDialog();
            if (result != DialogResult.OK) return;
            string FirstIP = form_CauHinh.IPBegin;
            string LastIP = form_CauHinh.IPEnd;
            string SubnetMask = form_CauHinh.SubnetMask;
            serverProgram.SetClientInfoList(FirstIP, LastIP, SubnetMask);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverProgram.Disconnect();
        }

        private void tool_chatAll_Click(object sender, EventArgs e)
        {
            FormChat frmChatAll = new FormChat(serverProgram);
            frmChatAll.Show();
        }

    }
}