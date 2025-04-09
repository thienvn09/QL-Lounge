using System.Drawing;

namespace Lounge
{
    partial class TrangChu
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
            this.pneTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTim1 = new System.Windows.Forms.Button();
            this.BAR = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlCha = new System.Windows.Forms.Panel();
            this.plnBan = new System.Windows.Forms.Panel();
            this.pneTitle.SuspendLayout();
            this.pnlCha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pneTitle
            // 
            this.pneTitle.Controls.Add(this.label1);
            this.pneTitle.Controls.Add(this.btnTim1);
            this.pneTitle.Controls.Add(this.BAR);
            this.pneTitle.Controls.Add(this.lblUser);
            this.pneTitle.Controls.Add(this.lblTime);
            this.pneTitle.Controls.Add(this.btnInfo);
            this.pneTitle.Controls.Add(this.btnExit);
            this.pneTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pneTitle.Location = new System.Drawing.Point(0, 0);
            this.pneTitle.Name = "pneTitle";
            this.pneTitle.Size = new System.Drawing.Size(1460, 57);
            this.pneTitle.TabIndex = 1;
            this.pneTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tìm bàn";
            // 
            // btnTim1
            // 
            this.btnTim1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim1.Location = new System.Drawing.Point(162, 18);
            this.btnTim1.Name = "btnTim1";
            this.btnTim1.Size = new System.Drawing.Size(43, 36);
            this.btnTim1.TabIndex = 6;
            this.btnTim1.Text = "🔍";
            this.btnTim1.UseVisualStyleBackColor = true;
            this.btnTim1.Click += new System.EventHandler(this.btnTim1_Click);
            // 
            // BAR
            // 
            this.BAR.AutoSize = true;
            this.BAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAR.Location = new System.Drawing.Point(25, 18);
            this.BAR.Name = "BAR";
            this.BAR.Size = new System.Drawing.Size(81, 36);
            this.BAR.TabIndex = 0;
            this.BAR.Text = "BAR";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(448, 25);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(164, 16);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Admin |  Operator |  Tư Anh";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(700, 25);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 16);
            this.lblTime.TabIndex = 3;
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(894, 18);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(60, 30);
            this.btnInfo.TabIndex = 4;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(982, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 30);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlCha
            // 
            this.pnlCha.Controls.Add(this.plnBan);
            this.pnlCha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCha.Location = new System.Drawing.Point(0, 57);
            this.pnlCha.Name = "pnlCha";
            this.pnlCha.Size = new System.Drawing.Size(1460, 696);
            this.pnlCha.TabIndex = 2;
            // 
            // plnBan
            // 
            this.plnBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnBan.Location = new System.Drawing.Point(0, 0);
            this.plnBan.Name = "plnBan";
            this.plnBan.Size = new System.Drawing.Size(1460, 696);
            this.plnBan.TabIndex = 0;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 753);
            this.Controls.Add(this.pnlCha);
            this.Controls.Add(this.pneTitle);
            this.Name = "TrangChu";
            this.Text = "TrangChu";
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.pneTitle.ResumeLayout(false);
            this.pneTitle.PerformLayout();
            this.pnlCha.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pneTitle;
        public System.Windows.Forms.Label BAR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTim1;
        private System.Windows.Forms.Panel pnlCha;
        private System.Windows.Forms.Panel plnBan;
    }
}