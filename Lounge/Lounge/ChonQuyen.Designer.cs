namespace Lounge
{
    partial class ChonQuyen
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnQT = new System.Windows.Forms.Button();
            this.btnBH = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 61);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chào mừng bạn đến với phần mềm quản lý Lounge";
            // 
            // BtnQT
            // 
            this.BtnQT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnQT.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnQT.Location = new System.Drawing.Point(14, 66);
            this.BtnQT.Name = "BtnQT";
            this.BtnQT.Size = new System.Drawing.Size(403, 311);
            this.BtnQT.TabIndex = 1;
            this.BtnQT.Text = "Quản trị hệ thống";
            this.BtnQT.UseVisualStyleBackColor = false;
            this.BtnQT.Click += new System.EventHandler(this.BtnQT_Click);
            // 
            // btnBH
            // 
            this.btnBH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBH.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.btnBH.Location = new System.Drawing.Point(430, 66);
            this.btnBH.Name = "btnBH";
            this.btnBH.Size = new System.Drawing.Size(403, 311);
            this.btnBH.TabIndex = 2;
            this.btnBH.Text = "Trang chủ";
            this.btnBH.UseVisualStyleBackColor = false;
            this.btnBH.Click += new System.EventHandler(this.btnBH_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(301, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(235, 71);
            this.button2.TabIndex = 4;
            this.button2.Text = "Đăng xuất";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ChonQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 495);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnBH);
            this.Controls.Add(this.BtnQT);
            this.Controls.Add(this.panel1);
            this.Name = "ChonQuyen";
            this.Text = "ChonQuyen";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnQT;
        private System.Windows.Forms.Button btnBH;
        private System.Windows.Forms.Button button2;
    }
}