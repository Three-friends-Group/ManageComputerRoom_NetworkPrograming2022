﻿namespace server
{
    partial class frmDieuKhienMayClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuKhienMayClient));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolKhoaChuot_SV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTroChuyen_SV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolKhoiDong_SV = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_Tatmay_SV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolThoat_SV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1259, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolKhoaChuot_SV,
            this.toolTroChuyen_SV,
            this.toolKhoiDong_SV,
            this.tool_Tatmay_SV,
            this.toolThoat_SV});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(71, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // toolKhoaChuot_SV
            // 
            this.toolKhoaChuot_SV.Image = ((System.Drawing.Image)(resources.GetObject("toolKhoaChuot_SV.Image")));
            this.toolKhoaChuot_SV.Name = "toolKhoaChuot_SV";
            this.toolKhoaChuot_SV.Size = new System.Drawing.Size(292, 30);
            this.toolKhoaChuot_SV.Text = "Khoá chuột và bàn phím";
            // 
            // toolTroChuyen_SV
            // 
            this.toolTroChuyen_SV.Image = ((System.Drawing.Image)(resources.GetObject("toolTroChuyen_SV.Image")));
            this.toolTroChuyen_SV.Name = "toolTroChuyen_SV";
            this.toolTroChuyen_SV.Size = new System.Drawing.Size(292, 30);
            this.toolTroChuyen_SV.Text = "Trò chuyện";
            this.toolTroChuyen_SV.Click += new System.EventHandler(this.toolTroChuyen_SV_Click);
            // 
            // toolKhoiDong_SV
            // 
            this.toolKhoiDong_SV.Image = ((System.Drawing.Image)(resources.GetObject("toolKhoiDong_SV.Image")));
            this.toolKhoiDong_SV.Name = "toolKhoiDong_SV";
            this.toolKhoiDong_SV.Size = new System.Drawing.Size(292, 30);
            this.toolKhoiDong_SV.Text = "Khởi động lại";
            // 
            // tool_Tatmay_SV
            // 
            this.tool_Tatmay_SV.Image = ((System.Drawing.Image)(resources.GetObject("tool_Tatmay_SV.Image")));
            this.tool_Tatmay_SV.Name = "tool_Tatmay_SV";
            this.tool_Tatmay_SV.Size = new System.Drawing.Size(292, 30);
            this.tool_Tatmay_SV.Text = "Tắt máy";
            // 
            // toolThoat_SV
            // 
            this.toolThoat_SV.Image = ((System.Drawing.Image)(resources.GetObject("toolThoat_SV.Image")));
            this.toolThoat_SV.Name = "toolThoat_SV";
            this.toolThoat_SV.Size = new System.Drawing.Size(292, 30);
            this.toolThoat_SV.Text = "Thoát";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(27, 29);
            this.toolStripMenuItem1.Text = " ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1259, 712);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmDieuKhienMayClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 745);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDieuKhienMayClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều khiển máy Clinet";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolKhoaChuot_SV;
        private System.Windows.Forms.ToolStripMenuItem toolTroChuyen_SV;
        private System.Windows.Forms.ToolStripMenuItem toolKhoiDong_SV;
        private System.Windows.Forms.ToolStripMenuItem tool_Tatmay_SV;
        private System.Windows.Forms.ToolStripMenuItem toolThoat_SV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}