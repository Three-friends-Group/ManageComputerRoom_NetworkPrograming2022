
namespace client
{
    partial class frmCauHinhClient
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
            this.txt_diaChiIP = new System.Windows.Forms.TextBox();
            this.txt_congKetNoi = new System.Windows.Forms.TextBox();
            this.txtCongRemote = new System.Windows.Forms.TextBox();
            this.lb_diaChiIP = new System.Windows.Forms.Label();
            this.lb_congKetNoi = new System.Windows.Forms.Label();
            this.lb_congRemote = new System.Windows.Forms.Label();
            this.btn_taoFile = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_diaChiIP
            // 
            this.txt_diaChiIP.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_diaChiIP.Location = new System.Drawing.Point(257, 61);
            this.txt_diaChiIP.Name = "txt_diaChiIP";
            this.txt_diaChiIP.Size = new System.Drawing.Size(324, 27);
            this.txt_diaChiIP.TabIndex = 0;
            // 
            // txt_congKetNoi
            // 
            this.txt_congKetNoi.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_congKetNoi.Location = new System.Drawing.Point(257, 114);
            this.txt_congKetNoi.Name = "txt_congKetNoi";
            this.txt_congKetNoi.Size = new System.Drawing.Size(324, 27);
            this.txt_congKetNoi.TabIndex = 1;
            // 
            // txtCongRemote
            // 
            this.txtCongRemote.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCongRemote.Location = new System.Drawing.Point(257, 164);
            this.txtCongRemote.Name = "txtCongRemote";
            this.txtCongRemote.Size = new System.Drawing.Size(324, 27);
            this.txtCongRemote.TabIndex = 2;
            // 
            // lb_diaChiIP
            // 
            this.lb_diaChiIP.AutoSize = true;
            this.lb_diaChiIP.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_diaChiIP.Location = new System.Drawing.Point(87, 64);
            this.lb_diaChiIP.Name = "lb_diaChiIP";
            this.lb_diaChiIP.Size = new System.Drawing.Size(82, 19);
            this.lb_diaChiIP.TabIndex = 3;
            this.lb_diaChiIP.Text = "Địa chỉ IP";
            // 
            // lb_congKetNoi
            // 
            this.lb_congKetNoi.AutoSize = true;
            this.lb_congKetNoi.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_congKetNoi.Location = new System.Drawing.Point(87, 117);
            this.lb_congKetNoi.Name = "lb_congKetNoi";
            this.lb_congKetNoi.Size = new System.Drawing.Size(101, 19);
            this.lb_congKetNoi.TabIndex = 4;
            this.lb_congKetNoi.Text = "Cổng kết nối";
            // 
            // lb_congRemote
            // 
            this.lb_congRemote.AutoSize = true;
            this.lb_congRemote.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_congRemote.Location = new System.Drawing.Point(87, 167);
            this.lb_congRemote.Name = "lb_congRemote";
            this.lb_congRemote.Size = new System.Drawing.Size(108, 19);
            this.lb_congRemote.TabIndex = 5;
            this.lb_congRemote.Text = "Cổng Remote";
            // 
            // btn_taoFile
            // 
            this.btn_taoFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_taoFile.ForeColor = System.Drawing.Color.White;
            this.btn_taoFile.Location = new System.Drawing.Point(257, 226);
            this.btn_taoFile.Name = "btn_taoFile";
            this.btn_taoFile.Size = new System.Drawing.Size(92, 32);
            this.btn_taoFile.TabIndex = 6;
            this.btn_taoFile.Text = "Tạo lại File";
            this.btn_taoFile.UseVisualStyleBackColor = false;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.Red;
            this.btn_Thoat.ForeColor = System.Drawing.Color.White;
            this.btn_Thoat.Location = new System.Drawing.Point(436, 226);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(92, 32);
            this.btn_Thoat.TabIndex = 7;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // frmCauHinhClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 286);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_taoFile);
            this.Controls.Add(this.lb_congRemote);
            this.Controls.Add(this.lb_congKetNoi);
            this.Controls.Add(this.lb_diaChiIP);
            this.Controls.Add(this.txtCongRemote);
            this.Controls.Add(this.txt_congKetNoi);
            this.Controls.Add(this.txt_diaChiIP);
            this.Name = "frmCauHinhClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_diaChiIP;
        private System.Windows.Forms.TextBox txt_congKetNoi;
        private System.Windows.Forms.TextBox txtCongRemote;
        private System.Windows.Forms.Label lb_diaChiIP;
        private System.Windows.Forms.Label lb_congKetNoi;
        private System.Windows.Forms.Label lb_congRemote;
        private System.Windows.Forms.Button btn_taoFile;
        private System.Windows.Forms.Button btn_Thoat;
    }
}