using common;
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
    public partial class frmChatOne : Form
    {
        ClientInfo clientInfo;
        public frmChatOne(ClientInfo clientInfo)
        {
            InitializeComponent();
            this.clientInfo = clientInfo;
        }

    
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(clientInfo);
            txtMsg.Clear();
            txtMsg.Focus();
            Console.WriteLine("hello bugs");
        }


        public void SendMessage(ClientInfo clientInfo)
        {
            if (clientInfo._status == ClientInfoStatus.Undefined || clientInfo._status == ClientInfoStatus.Disconnected)
            {
                MessageBox.Show("Chức năng hiện tại không khả dụng");
            }
            if (txtMsg.Text != String.Empty)
            {
                Console.WriteLine(txtMsg.Text);
                DataMethods dataMethod = new DataMethods(DataMethodsType.SendMessageToOne, txtMsg.Text);
                clientInfo._socket.Send(dataMethod.Serialize());
            }
            else
            {
                MessageBox.Show("Chuỗi rỗng");
            }
        }
    }
}
