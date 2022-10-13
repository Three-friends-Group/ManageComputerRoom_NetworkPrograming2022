using client;
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
    public partial class frmClient : Form
    {

        ClientProgram clientProgram;
        private const int SERVER_PORT = 9998;
        private const int PORT_REMOTE = 9992;
        private const string ip = "192.168.1.8";
        LockScreen lockScreen;


        public frmClient()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

            CheckForIllegalCrossThreadCalls = false;

            clientProgram = new ClientProgram(ip, SERVER_PORT, PORT_REMOTE);
            clientProgram.OnReceiveMessage += ClientProgram_OnReceiveMessage;
            clientProgram.OnRemoteDesktop += ClientProgram_OnRemoteDesktop;
            clientProgram.OnUnLockScreen = OnUnLockScreen;
            clientProgram.OnLockScreen = OnLockScreen;

            clientProgram.Connect();
        }
        private void OnLockScreen()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lockScreen = new LockScreen();

                    lockScreen.ShowDialog();
                });
            }
            else
            {
                lockScreen = new LockScreen();
                lockScreen.Show();
            }
        }

        private void OnUnLockScreen()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lockScreen.close();
                });
            }
            else
            {
                lockScreen.close();
            }
        }

        private void ClientProgram_OnRemoteDesktop(string obj)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                });
            }
            else
            {
            }
        }

        private void ClientProgram_OnReceiveMessage(string obj)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    common.Uitls.AddIncomming(obj, pnContainer);
                });
            }
            else
            {
                common.Uitls.AddIncomming(obj, pnContainer);
            }
        }


        // close
        private void toolThoat_SV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientProgram.Close();
        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            common.Uitls.AddOutGoing(txtMessage.Text, pnContainer);
            txtMessage.Text = String.Empty;
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientProgram.Close();
        }
    }
}
