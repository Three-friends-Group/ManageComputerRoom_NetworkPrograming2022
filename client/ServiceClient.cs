using server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    partial class ServiceClient : ServiceBase
    {
        ClientProgram clientProgram;
        private const int SERVER_PORT = 9998;
        private const int PORT_REMOTE = 9992;
        private const string ip = "127.0.0.1";
        LockScreen lockScreen;


        public ServiceClient()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            clientProgram = new ClientProgram(ip, SERVER_PORT, PORT_REMOTE);
            clientProgram.OnReceiveMessage += ClientProgram_OnReceiveMessage;
            clientProgram.OnRemoteDesktop += ClientProgram_OnRemoteDesktop;
            clientProgram.OnUnLockScreen = OnUnLockScreen;
            clientProgram.OnLockScreen = OnLockScreen;

            clientProgram.Connect();
        }

        private void OnLockScreen()
        {
            lockScreen = new LockScreen();

            lockScreen.ShowDialog();
        }

        private void OnUnLockScreen()
        {
            lockScreen.close();
        }

        private void ClientProgram_OnRemoteDesktop(string obj)
        {
        }

        private void ClientProgram_OnReceiveMessage(string obj)
        {
            //        common.Uitls.AddIncomming(obj, pnContainer);
            //    });
            //}
            //else
            //{
            //    common.Uitls.AddIncomming(obj, pnContainer);
            //}
        }


        // close
        private void toolThoat_SV_Click(object sender, EventArgs e)
        {
            //this.Close();
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

            //common.Uitls.AddOutGoing(txtMessage.Text, pnContainer);
            //txtMessage.Text = String.Empty;
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
