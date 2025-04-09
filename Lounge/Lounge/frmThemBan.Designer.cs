namespace Lounge
{
    partial class frmThemBan
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
            this.txtSoBan = new System.Windows.Forms.TextBox();
            this.txtSoCho = new System.Windows.Forms.TextBox();
            this.cbbViTri = new System.Windows.Forms.ComboBox();
            this.pneThem = new System.Windows.Forms.Panel();
            this.text = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.ComboBox();
            this.pneThem.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSoBan
            // 
            this.txtSoBan.Location = new System.Drawing.Point(191, 69);
            this.txtSoBan.Multiline = true;
            this.txtSoBan.Name = "txtSoBan";
            this.txtSoBan.Size = new System.Drawing.Size(197, 30);
            this.txtSoBan.TabIndex = 0;
            // 
            // txtSoCho
            // 
            this.txtSoCho.Location = new System.Drawing.Point(191, 125);
            this.txtSoCho.Multiline = true;
            this.txtSoCho.Name = "txtSoCho";
            this.txtSoCho.Size = new System.Drawing.Size(197, 30);
            this.txtSoCho.TabIndex = 1;
            // 
            // cbbViTri
            // 
            this.cbbViTri.FormattingEnabled = true;
            this.cbbViTri.Location = new System.Drawing.Point(191, 174);
            this.cbbViTri.Name = "cbbViTri";
            this.cbbViTri.Size = new System.Drawing.Size(197, 24);
            this.cbbViTri.TabIndex = 2;
            // 
            // pneThem
            // 
            this.pneThem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pneThem.Controls.Add(this.txtTrangThai);
            this.pneThem.Controls.Add(this.label3);
            this.pneThem.Controls.Add(this.label2);
            this.pneThem.Controls.Add(this.label1);
            this.pneThem.Controls.Add(this.button2);
            this.pneThem.Controls.Add(this.button1);
            this.pneThem.Controls.Add(this.text);
            this.pneThem.Controls.Add(this.cbbViTri);
            this.pneThem.Controls.Add(this.txtSoBan);
            this.pneThem.Controls.Add(this.txtSoCho);
            this.pneThem.Location = new System.Drawing.Point(112, 45);
            this.pneThem.Name = "pneThem";
            this.pneThem.Size = new System.Drawing.Size(555, 341);
            this.pneThem.TabIndex = 3;
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text.Location = new System.Drawing.Point(170, 11);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(206, 46);
            this.text.TabIndex = 1;
            this.text.Text = "Thêm bàn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(291, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 47);
            this.button2.TabIndex = 4;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "số bàn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "số chỗ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(108, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vị trí";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.FormattingEnabled = true;
            this.txtTrangThai.Location = new System.Drawing.Point(191, 219);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(197, 24);
            this.txtTrangThai.TabIndex = 8;
            // 
            // frmThemBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pneThem);
            this.Name = "frmThemBan";
            this.Text = "frmThemBan";
            this.Load += new System.EventHandler(this.frmThemBan_Load);
            this.pneThem.ResumeLayout(false);
            this.pneThem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSoBan;
        private System.Windows.Forms.TextBox txtSoCho;
        private System.Windows.Forms.ComboBox cbbViTri;
        private System.Windows.Forms.Panel pneThem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtTrangThai;
    }
}