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
    public partial class frmChat : Form
    {
        public frmChat()
        {
            InitializeComponent();
        }

        // trò chuyện 
        private void toolTroChuyen_SV_Click(object sender, EventArgs e)
        {
        }

        // close
        private void toolThoat_SV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox1.Focus();
            Console.WriteLine("hello bugs");
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
