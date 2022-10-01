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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // mở form điều khiển
        private void toolDieuKhien_SV_Click(object sender, EventArgs e)
        {
            var form_DieuKhien = new frmDieuKhienMayClient();
            form_DieuKhien.Show();
        }

        // mở form trò chuyện
        private void toolTroChuyen_SV_Click(object sender, EventArgs e)
        {
            var form_TroChuyen = new frmTroChuyen();
            form_TroChuyen.Show();
        }

        // mở form cấu hình
        private void btnCauHinh_SV_Click(object sender, EventArgs e)
        {
            var form_CauHinh = new frmCauHinh_SV();
            form_CauHinh.Show();
        }

        // mở form gửi tin nhắn gửi tất cả qua nút click button
        private void btnGuiTinNhanAll_SV_Click(object sender, EventArgs e)
        {
            var form_GuiTinNhanAll = new frmGuiTinNhanTatCaClinet();
            form_GuiTinNhanAll.Show();
        }

        // thoát chương trình
        private void btnThoat_SV_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
