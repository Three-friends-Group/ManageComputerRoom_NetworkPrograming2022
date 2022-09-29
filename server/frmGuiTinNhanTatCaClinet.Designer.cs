namespace server
{
    partial class frmGuiTinNhanTatCaClinet
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSentAll_SV = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGuiTatCa_SV = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbSentAll_SV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 96);
            this.panel1.TabIndex = 1;
            // 
            // lbSentAll_SV
            // 
            this.lbSentAll_SV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSentAll_SV.AutoSize = true;
            this.lbSentAll_SV.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSentAll_SV.Location = new System.Drawing.Point(340, 21);
            this.lbSentAll_SV.Name = "lbSentAll_SV";
            this.lbSentAll_SV.Size = new System.Drawing.Size(571, 42);
            this.lbSentAll_SV.TabIndex = 0;
            this.lbSentAll_SV.Text = "Gửi tin nhắn cho tất cả các máy";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGuiTatCa_SV);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 622);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1259, 123);
            this.panel2.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 96);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1259, 526);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(57, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(908, 30);
            this.textBox1.TabIndex = 0;
            // 
            // btnGuiTatCa_SV
            // 
            this.btnGuiTatCa_SV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuiTatCa_SV.BorderRadius = 5;
            this.btnGuiTatCa_SV.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuiTatCa_SV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuiTatCa_SV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuiTatCa_SV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuiTatCa_SV.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiTatCa_SV.ForeColor = System.Drawing.Color.White;
            this.btnGuiTatCa_SV.Location = new System.Drawing.Point(1063, 38);
            this.btnGuiTatCa_SV.Name = "btnGuiTatCa_SV";
            this.btnGuiTatCa_SV.Size = new System.Drawing.Size(93, 45);
            this.btnGuiTatCa_SV.TabIndex = 1;
            this.btnGuiTatCa_SV.Text = "Gửi";
            // 
            // frmGuiTinNhanTatCaClinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 745);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmGuiTinNhanTatCaClinet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gửi tin nhắn cho tất cả các clinet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbSentAll_SV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private Guna.UI2.WinForms.Guna2Button btnGuiTatCa_SV;
    }
}