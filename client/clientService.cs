using client;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    partial class clientService : ServiceBase
    {

        ClientProgram clientProgram;
        private const int SERVER_PORT = 9998;
        private const int PORT_REMOTE = 9992;
        private const string ip = "127.0.0.1";
        LockScreen lockScreen;



        public clientService()
        {
            InitializeComponent();
            clientProgram = new ClientProgram(ip, SERVER_PORT, PORT_REMOTE);
            clientProgram.OnReceiveMessage += ClientProgram_OnReceiveMessage;
            clientProgram.OnRemoteDesktop += ClientProgram_OnRemoteDesktop;
            clientProgram.OnUnLockScreen = OnUnLockScreen;
            clientProgram.OnLockScreen = OnLockScreen;
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            //clientProgram.OnServerOff += ClientProgram_OnServerOff;
            clientProgram.Connect();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
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

         

    }
}
