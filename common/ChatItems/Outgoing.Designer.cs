﻿namespace common.ChatItems
{

    partial class Outgoing
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.guna2Shapes1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(167, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 88);
            this.panel1.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMsg.Location = new System.Drawing.Point(32, 19);
            this.lblMsg.MaximumSize = new System.Drawing.Size(450, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(46, 18);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.Text = "label1";
            // 
            // guna2Shapes1
            // 
            this.guna2Shapes1.BorderThickness = 0;
            this.guna2Shapes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Shapes1.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2Shapes1.LineThickness = 1;
            this.guna2Shapes1.Location = new System.Drawing.Point(0, 0);
            this.guna2Shapes1.Name = "guna2Shapes1";
            this.guna2Shapes1.PolygonSkip = 1;
            this.guna2Shapes1.Rotate = 0F;
            this.guna2Shapes1.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            this.guna2Shapes1.Size = new System.Drawing.Size(485, 88);
            this.guna2Shapes1.TabIndex = 2;
            this.guna2Shapes1.Text = "guna2Shapes1";
            this.guna2Shapes1.Zoom = 97;
            // 
            // Outgoing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Outgoing";
            this.Size = new System.Drawing.Size(652, 88);
            this.Resize += new System.EventHandler(this.Outgoing_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMsg;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes1;
    }

}
