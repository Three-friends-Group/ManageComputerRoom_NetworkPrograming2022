﻿using client;
using common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private const string ip = "127.0.0.1";
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
            clientProgram.OnServerOff += ClientProgram_OnServerOff;

            clientProgram.Connect();
        }

        private void ClientProgram_OnServerOff(string obj)
        {
            Application.Exit();
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
            clientProgram.Close();
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
            clientProgram.Send(new DataMethods(DataMethodsType.SendMessageToServer, Dns.GetHostName() + ": " + txtMessage.Text));
            txtMessage.Text = String.Empty;
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientProgram.Close();
        }

        private void toolKhoiDong_SV_Click(object sender, EventArgs e)
        {

            Process process = new Process();
            ProcessStartInfo proccessInfo = new ProcessStartInfo();
            proccessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proccessInfo.FileName = "shutdown.exe";
            proccessInfo.Arguments = "/f -s -t 00";
            process.StartInfo = proccessInfo;
            process.Start();
            this.Close();
        }

        private void tool_Tatmay_SV_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo proccessInfo = new ProcessStartInfo();
            proccessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proccessInfo.FileName = "shutdown.exe";
            proccessInfo.Arguments = "/f -r -t 00";
            process.StartInfo = proccessInfo;
            process.Start();
            this.Close();
        }
    }
}
