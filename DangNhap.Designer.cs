namespace QLBH_MIEU
{
    partial class DangNhap
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
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.lblMK = new System.Windows.Forms.Label();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.lblDangNhap = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDangKy = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbeyeOpen = new System.Windows.Forms.PictureBox();
            this.pbeyeClose = new System.Windows.Forms.PictureBox();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeClose)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(282, 94);
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(129, 20);
            this.txtMK.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtMK, "Nhập mật khẩu tài khoản");
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(282, 60);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(129, 20);
            this.txtTenDN.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtTenDN, "Nhập tên đăng nhập");
            // 
            // lblMK
            // 
            this.lblMK.AutoSize = true;
            this.lblMK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMK.Location = new System.Drawing.Point(155, 98);
            this.lblMK.Name = "lblMK";
            this.lblMK.Size = new System.Drawing.Size(81, 16);
            this.lblMK.TabIndex = 26;
            this.lblMK.Text = "Mật khẩu (*):";
            // 
            // lblTenDN
            // 
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTenDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDN.Location = new System.Drawing.Point(155, 61);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(118, 16);
            this.lblTenDN.TabIndex = 25;
            this.lblTenDN.Text = "Tên đăng nhập (*):";
            // 
            // lblDangNhap
            // 
            this.lblDangNhap.AutoSize = true;
            this.lblDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangNhap.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblDangNhap.Location = new System.Drawing.Point(208, 17);
            this.lblDangNhap.Name = "lblDangNhap";
            this.lblDangNhap.Size = new System.Drawing.Size(162, 29);
            this.lblDangNhap.TabIndex = 24;
            this.lblDangNhap.Text = "ĐĂNG NHẬP";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.SpringGreen;
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangNhap.Location = new System.Drawing.Point(154, 134);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(257, 28);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangKy.Location = new System.Drawing.Point(154, 180);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(115, 28);
            this.btnDangKy.TabIndex = 4;
            this.btnDangKy.Text = "Đăng Ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLBH_MIEU.Properties.Resources.sign_in;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // pbeyeOpen
            // 
            this.pbeyeOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbeyeOpen.Image = global::QLBH_MIEU.Properties.Resources.eyeOpen;
            this.pbeyeOpen.Location = new System.Drawing.Point(417, 95);
            this.pbeyeOpen.Name = "pbeyeOpen";
            this.pbeyeOpen.Size = new System.Drawing.Size(26, 19);
            this.pbeyeOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbeyeOpen.TabIndex = 30;
            this.pbeyeOpen.TabStop = false;
            this.pbeyeOpen.Click += new System.EventHandler(this.pbeyeOpen_Click);
            // 
            // pbeyeClose
            // 
            this.pbeyeClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbeyeClose.Image = global::QLBH_MIEU.Properties.Resources.eyeClose;
            this.pbeyeClose.Location = new System.Drawing.Point(417, 95);
            this.pbeyeClose.Name = "pbeyeClose";
            this.pbeyeClose.Size = new System.Drawing.Size(26, 19);
            this.pbeyeClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbeyeClose.TabIndex = 29;
            this.pbeyeClose.TabStop = false;
            this.pbeyeClose.Click += new System.EventHandler(this.pbeyeClose_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Location = new System.Drawing.Point(296, 180);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(115, 28);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 226);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.pbeyeClose);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.lblMK);
            this.Controls.Add(this.lblTenDN);
            this.Controls.Add(this.lblDangNhap);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbeyeOpen);
            this.Controls.Add(this.btnDangKy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label lblMK;
        private System.Windows.Forms.Label lblTenDN;
        private System.Windows.Forms.Label lblDangNhap;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbeyeOpen;
        private System.Windows.Forms.PictureBox pbeyeClose;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnThoat;
    }
}