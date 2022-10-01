using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {

        }

        private void tms_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tms_cauHinh_Click(object sender, EventArgs e)
        {
            var frmCauHinh = new frmCauHinhClient();
            frmCauHinh.Show();
        }

        
    }
}
