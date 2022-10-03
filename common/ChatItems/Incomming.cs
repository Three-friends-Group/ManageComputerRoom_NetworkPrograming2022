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
    public partial class Incomming : UserControl
    {
        private string message;
        public Incomming()
        {
            InitializeComponent();

        }
        public Incomming(string msg)
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
            lblMsg.Height = common.Uitls.GetTextHeight(lblMsg);
            Height = lblMsg.Height + 40;
        }

        private void Incomming_Resize(object sender, EventArgs e)
        {
            AdjustHeight();
        }
    }

}
