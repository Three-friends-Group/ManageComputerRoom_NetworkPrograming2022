namespace server
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnMain_SV = new System.Windows.Forms.Panel();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_cauHinhSV = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_chatAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_RestartAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_shutDown_All = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_lockAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolThoat_SV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSLOnline = new System.Windows.Forms.Label();
            this.lblSLMay = new System.Windows.Forms.Label();
            this.lbTongSoMay_SV = new System.Windows.Forms.Label();
            this.lbTongSoOnline_SV = new System.Windows.Forms.Label();
            this.pnMain_SV.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain_SV
            // 
            this.pnMain_SV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMain_SV.Controls.Add(this.flpMain);
            this.pnMain_SV.Controls.Add(this.pnTop);
            this.pnMain_SV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain_SV.Location = new System.Drawing.Point(0, 0);
            this.pnMain_SV.Margin = new System.Windows.Forms.Padding(2);
            this.pnMain_SV.Name = "pnMain_SV";
            this.pnMain_SV.Size = new System.Drawing.Size(944, 605);
            this.pnMain_SV.TabIndex = 0;
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.AutoSize = true;
            this.flpMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(0, 71);
            this.flpMain.Margin = new System.Windows.Forms.Padding(24);
            this.flpMain.Name = "flpMain";
            this.flpMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flpMain.Size = new System.Drawing.Size(942, 532);
            this.flpMain.TabIndex = 4;
            // 
            // pnTop
            // 
            this.pnTop.AutoScroll = true;
            this.pnTop.Controls.Add(this.menuStrip1);
            this.pnTop.Controls.Add(this.lblSLOnline);
            this.pnTop.Controls.Add(this.lblSLMay);
            this.pnTop.Controls.Add(this.lbTongSoMay_SV);
            this.pnTop.Controls.Add(this.lbTongSoOnline_SV);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(942, 71);
            this.pnTop.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(942, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_cauHinhSV,
            this.tool_chatAll,
            this.tool_RestartAll,
            this.tool_shutDown_All,
            this.tool_lockAll,
            this.toolThoat_SV});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // tool_cauHinhSV
            // 
            this.tool_cauHinhSV.Image = ((System.Drawing.Image)(resources.GetObject("tool_cauHinhSV.Image")));
            this.tool_cauHinhSV.Name = "tool_cauHinhSV";
            this.tool_cauHinhSV.Size = new System.Drawing.Size(232, 26);
            this.tool_cauHinhSV.Text = "Cấu hình";
            this.tool_cauHinhSV.Click += new System.EventHandler(this.tool_cauHinhSV_Click);
            // 
            // tool_chatAll
            // 
            this.tool_chatAll.Image = ((System.Drawing.Image)(resources.GetObject("tool_chatAll.Image")));
            this.tool_chatAll.Name = "tool_chatAll";
            this.tool_chatAll.Size = new System.Drawing.Size(232, 26);
            this.tool_chatAll.Text = "Gửi tin nhắn đến tất cả";
            this.tool_chatAll.Click += new System.EventHandler(this.tool_chatAll_Click);
            // 
            // tool_RestartAll
            // 
            this.tool_RestartAll.Image = ((System.Drawing.Image)(resources.GetObject("tool_RestartAll.Image")));
            this.tool_RestartAll.Name = "tool_RestartAll";
            this.tool_RestartAll.Size = new System.Drawing.Size(232, 26);
            this.tool_RestartAll.Text = "Khởi động lại tất cả";
            this.tool_RestartAll.Click += new System.EventHandler(this.tool_RestartAll_Click);
            // 
            // tool_shutDown_All
            // 
            this.tool_shutDown_All.Image = ((System.Drawing.Image)(resources.GetObject("tool_shutDown_All.Image")));
            this.tool_shutDown_All.Name = "tool_shutDown_All";
            this.tool_shutDown_All.Size = new System.Drawing.Size(232, 26);
            this.tool_shutDown_All.Text = "Tắt máy tất cả";
            this.tool_shutDown_All.Click += new System.EventHandler(this.tool_shutDown_All_Click);
            // 
            // tool_lockAll
            // 
            this.tool_lockAll.Name = "tool_lockAll";
            this.tool_lockAll.Size = new System.Drawing.Size(232, 26);
            this.tool_lockAll.Text = "Khóa tất cả";
            this.tool_lockAll.Click += new System.EventHandler(this.tool_lockAll_Click);
            // 
            // toolThoat_SV
            // 
            this.toolThoat_SV.Image = ((System.Drawing.Image)(resources.GetObject("toolThoat_SV.Image")));
            this.toolThoat_SV.Name = "toolThoat_SV";
            this.toolThoat_SV.Size = new System.Drawing.Size(232, 26);
            this.toolThoat_SV.Text = "Thoát";
            this.toolThoat_SV.Click += new System.EventHandler(this.toolThoat_SV_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 24);
            this.toolStripMenuItem1.Text = " ";
            // 
            // lblSLOnline
            // 
            this.lblSLOnline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSLOnline.AutoSize = true;
            this.lblSLOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLOnline.ForeColor = System.Drawing.Color.Green;
            this.lblSLOnline.Location = new System.Drawing.Point(677, 26);
            this.lblSLOnline.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSLOnline.Name = "lblSLOnline";
            this.lblSLOnline.Size = new System.Drawing.Size(30, 31);
            this.lblSLOnline.TabIndex = 3;
            this.lblSLOnline.Text = "0";
            // 
            // lblSLMay
            // 
            this.lblSLMay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSLMay.AutoSize = true;
            this.lblSLMay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLMay.ForeColor = System.Drawing.Color.Coral;
            this.lblSLMay.Location = new System.Drawing.Point(302, 26);
            this.lblSLMay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSLMay.Name = "lblSLMay";
            this.lblSLMay.Size = new System.Drawing.Size(30, 31);
            this.lblSLMay.TabIndex = 2;
            this.lblSLMay.Text = "0";
            // 
            // lbTongSoMay_SV
            // 
            this.lbTongSoMay_SV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTongSoMay_SV.AutoSize = true;
            this.lbTongSoMay_SV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongSoMay_SV.Location = new System.Drawing.Point(146, 31);
            this.lbTongSoMay_SV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTongSoMay_SV.Name = "lbTongSoMay_SV";
            this.lbTongSoMay_SV.Size = new System.Drawing.Size(155, 26);
            this.lbTongSoMay_SV.TabIndex = 0;
            this.lbTongSoMay_SV.Text = "Tổng số máy:";
            // 
            // lbTongSoOnline_SV
            // 
            this.lbTongSoOnline_SV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTongSoOnline_SV.AutoSize = true;
            this.lbTongSoOnline_SV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongSoOnline_SV.Location = new System.Drawing.Point(509, 31);
            this.lbTongSoOnline_SV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTongSoOnline_SV.Name = "lbTongSoOnline_SV";
            this.lbTongSoOnline_SV.Size = new System.Drawing.Size(164, 26);
            this.lbTongSoOnline_SV.TabIndex = 1;
            this.lbTongSoOnline_SV.Text = "Số máy online";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(944, 605);
            this.Controls.Add(this.pnMain_SV);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.pnMain_SV.ResumeLayout(false);
            this.pnMain_SV.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain_SV;
        private System.Windows.Forms.Label lbTongSoMay_SV;
        private System.Windows.Forms.Label lbTongSoOnline_SV;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Label lblSLOnline;
        private System.Windows.Forms.Label lblSLMay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tool_cauHinhSV;
        private System.Windows.Forms.ToolStripMenuItem tool_chatAll;
        private System.Windows.Forms.ToolStripMenuItem tool_RestartAll;
        private System.Windows.Forms.ToolStripMenuItem tool_shutDown_All;
        private System.Windows.Forms.ToolStripMenuItem toolThoat_SV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tool_lockAll;
    }
}

