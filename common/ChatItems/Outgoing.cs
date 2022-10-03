using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace common.ChatItems
{
    public partial class Outgoing : UserControl
    {
        private string message;
        public Outgoing()
        {
            InitializeComponent();
        }

        public Outgoing(string msg)
        {
            message = msg;
            InitializeComponent();
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                AdjustHeight();
            }
        }

        private void AdjustHeight()
        {
            lblMsg.Text = message;
            lblMsg.Height = common.Uitls.GetTextHeight(lblMsg) + 10;
            Height = lblMsg.Height + 40;
        }

        private void Outgoing_Resize(object sender, EventArgs e)
        {
            AdjustHeight();
        }
    }

}
