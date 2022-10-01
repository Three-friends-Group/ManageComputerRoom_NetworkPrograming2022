namespace client
{
    partial class frmClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_NhapTN_Client = new System.Windows.Forms.TextBox();
            this.btn_Gui_Client = new System.Windows.Forms.Button();
            this.lb_Menu_Client = new System.Windows.Forms.Label();
            this.cms_Menu_Client = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tms_cauHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.tms_ketNoiLai = new System.Windows.Forms.ToolStripMenuItem();
            this.tms_thoat = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_thongTin = new System.Windows.Forms.GroupBox();
            this.lb_diaChiIP = new System.Windows.Forms.Label();
            this.lb_tinhTrang = new System.Windows.Forms.Label();
            this.lb_tenMay = new System.Windows.Forms.Label();
            this.gb_chat = new System.Windows.Forms.GroupBox();
            this.cms_Menu_Client.SuspendLayout();
            this.gb_thongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_NhapTN_Client
            // 
            this.txt_NhapTN_Client.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NhapTN_Client.Location = new System.Drawing.Point(107, 402);
            this.txt_NhapTN_Client.Name = "txt_NhapTN_Client";
            this.txt_NhapTN_Client.Size = new System.Drawing.Size(339, 27);
            this.txt_NhapTN_Client.TabIndex = 0;
            this.txt_NhapTN_Client.Text = "Nhập tin nhắn";
            // 
            // btn_Gui_Client
            // 
            this.btn_Gui_Client.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Gui_Client.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Gui_Client.Location = new System.Drawing.Point(523, 394);
            this.btn_Gui_Client.Name = "btn_Gui_Client";
            this.btn_Gui_Client.Size = new System.Drawing.Size(122, 38);
            this.btn_Gui_Client.TabIndex = 1;
            this.btn_Gui_Client.Text = "Gửi";
            this.btn_Gui_Client.UseVisualStyleBackColor = false;
            // 
            // lb_Menu_Client
            // 
            this.lb_Menu_Client.AutoSize = true;
            this.lb_Menu_Client.ContextMenuStrip = this.cms_Menu_Client;
            this.lb_Menu_Client.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Menu_Client.Location = new System.Drawing.Point(12, 9);
            this.lb_Menu_Client.Name = "lb_Menu_Client";
            this.lb_Menu_Client.Size = new System.Drawing.Size(49, 19);
            this.lb_Menu_Client.TabIndex = 2;
            this.lb_Menu_Client.Text = "Menu";
            // 
            // cms_Menu_Client
            // 
            this.cms_Menu_Client.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_Menu_Client.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tms_cauHinh,
            this.tms_ketNoiLai,
            this.tms_thoat});
            this.cms_Menu_Client.Name = "cms_Menu_Client";
            this.cms_Menu_Client.Size = new System.Drawing.Size(146, 76);
            // 
            // tms_cauHinh
            // 
            this.tms_cauHinh.Name = "tms_cauHinh";
            this.tms_cauHinh.Size = new System.Drawing.Size(210, 24);
            this.tms_cauHinh.Text = "Cấu hình";
            this.tms_cauHinh.Click += new System.EventHandler(this.tms_cauHinh_Click);
            // 
            // tms_ketNoiLai
            // 
            this.tms_ketNoiLai.Name = "tms_ketNoiLai";
            this.tms_ketNoiLai.Size = new System.Drawing.Size(145, 24);
            this.tms_ketNoiLai.Text = "Kết nối lại";
            // 
            // tms_thoat
            // 
            this.tms_thoat.Name = "tms_thoat";
            this.tms_thoat.Size = new System.Drawing.Size(145, 24);
            this.tms_thoat.Text = "Thoát";
            this.tms_thoat.Click += new System.EventHandler(this.tms_thoat_Click);
            // 
            // gb_thongTin
            // 
            this.gb_thongTin.BackColor = System.Drawing.Color.White;
            this.gb_thongTin.Controls.Add(this.lb_diaChiIP);
            this.gb_thongTin.Controls.Add(this.lb_tinhTrang);
            this.gb_thongTin.Controls.Add(this.lb_tenMay);
            this.gb_thongTin.Location = new System.Drawing.Point(-1, 35);
            this.gb_thongTin.Name = "gb_thongTin";
            this.gb_thongTin.Size = new System.Drawing.Size(803, 110);
            this.gb_thongTin.TabIndex = 3;
            this.gb_thongTin.TabStop = false;
            // 
            // lb_diaChiIP
            // 
            this.lb_diaChiIP.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_diaChiIP.Location = new System.Drawing.Point(222, 46);
            this.lb_diaChiIP.Name = "lb_diaChiIP";
            this.lb_diaChiIP.Size = new System.Drawing.Size(95, 22);
            this.lb_diaChiIP.TabIndex = 2;
            this.lb_diaChiIP.Text = "Địa chỉ IP:";
            // 
            // lb_tinhTrang
            // 
            this.lb_tinhTrang.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tinhTrang.Location = new System.Drawing.Point(219, 72);
            this.lb_tinhTrang.Name = "lb_tinhTrang";
            this.lb_tinhTrang.Size = new System.Drawing.Size(95, 22);
            this.lb_tinhTrang.TabIndex = 1;
            this.lb_tinhTrang.Text = "Tình trạng :";
            // 
            // lb_tenMay
            // 
            this.lb_tenMay.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tenMay.Location = new System.Drawing.Point(222, 18);
            this.lb_tenMay.Name = "lb_tenMay";
            this.lb_tenMay.Size = new System.Drawing.Size(78, 22);
            this.lb_tenMay.TabIndex = 0;
            this.lb_tenMay.Text = "Tên máy: ";
            // 
            // gb_chat
            // 
            this.gb_chat.BackColor = System.Drawing.Color.White;
            this.gb_chat.Location = new System.Drawing.Point(42, 178);
            this.gb_chat.Name = "gb_chat";
            this.gb_chat.Size = new System.Drawing.Size(705, 210);
            this.gb_chat.TabIndex = 4;
            this.gb_chat.TabStop = false;
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gb_chat);
            this.Controls.Add(this.gb_thongTin);
            this.Controls.Add(this.lb_Menu_Client);
            this.Controls.Add(this.btn_Gui_Client);
            this.Controls.Add(this.txt_NhapTN_Client);
            this.Name = "frmClient";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.cms_Menu_Client.ResumeLayout(false);
            this.gb_thongTin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_NhapTN_Client;
        private System.Windows.Forms.Button btn_Gui_Client;
        private System.Windows.Forms.Label lb_Menu_Client;
        private System.Windows.Forms.ContextMenuStrip cms_Menu_Client;
        private System.Windows.Forms.ToolStripMenuItem tms_cauHinh;
        private System.Windows.Forms.ToolStripMenuItem tms_ketNoiLai;
        private System.Windows.Forms.ToolStripMenuItem tms_thoat;
        private System.Windows.Forms.GroupBox gb_thongTin;
        private System.Windows.Forms.Label lb_diaChiIP;
        private System.Windows.Forms.Label lb_tinhTrang;
        private System.Windows.Forms.Label lb_tenMay;
        private System.Windows.Forms.GroupBox gb_chat;
    }
}

