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
    public partial class frmSetTime : Form
    {
        public string timeDelay { get; private set; }
        public frmSetTime()
        {
            InitializeComponent();
            this.cboChooseTime.Items.Add("Now");
            this.cboChooseTime.Items.Add("1 minutes later");
            this.cboChooseTime.Items.Add("3 minutes later");
            this.cboChooseTime.Items.Add("5 minutes later");
            this.cboChooseTime.Items.Add("10 minutes later");
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {

            timeDelay = cboChooseTime.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
