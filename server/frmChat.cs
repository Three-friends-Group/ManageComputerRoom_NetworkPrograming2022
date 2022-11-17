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
    public partial class FormChat : Form
    {

        ServerProgram serverProgram;

        public FormChat(ServerProgram serverProgram)
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            this.serverProgram = serverProgram;
            serverProgram.OnRecieveMessageFromClient += ServerProgram_OnRecieveMessageFromClient;
        }

        private void ServerProgram_OnRecieveMessageFromClient(string obj)
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            common.Uitls.AddOutGoing(txtMessage.Text, pnContainer);
            serverProgram.chatAll(txtMessage.Text);
            txtMessage.Text = String.Empty;
        }
    }
}
