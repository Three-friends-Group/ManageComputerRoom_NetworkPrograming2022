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
    public partial class frmCauHinh_SV : Form
    {
        public string IPBegin { get; private set; }
        public string IPEnd { get; private set; }
        public string SubnetMask { get; private set; }
        public frmCauHinh_SV()
        {
            InitializeComponent();
        }


        private void bnButton_Thoat_SV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            IPBegin = txtIPBegin.Text;
            IPEnd = txtIpEnd.Text;
            SubnetMask = txtSubnetMask.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
