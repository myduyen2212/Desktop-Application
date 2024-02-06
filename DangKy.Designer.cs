namespace QLBH_MIEU
{
    partial class DangKy
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
            this.txtTenDK = new System.Windows.Forms.TextBox();
            this.lblMK = new System.Windows.Forms.Label();
            this.lblTenDK = new System.Windows.Forms.Label();
            this.lblDangKy = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtMKNL = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbeyeOpenMK = new System.Windows.Forms.PictureBox();
            this.pbeyeCloseMK = new System.Windows.Forms.PictureBox();
            this.pbDangKy = new System.Windows.Forms.PictureBox();
            this.pbeyeCloseMKNL = new System.Windows.Forms.PictureBox();
            this.pbeyeOpenMKNL = new System.Windows.Forms.PictureBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblMaNV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeOpenMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeCloseMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDangKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeCloseMKNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeOpenMKNL)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(302, 128);
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(118, 20);
            this.txtMK.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtMK, "Nhập mật khẩu đăng ký tài khoản");
            // 
            // txtTenDK
            // 
            this.txtTenDK.Location = new System.Drawing.Point(302, 94);
            this.txtTenDK.Name = "txtTenDK";
            this.txtTenDK.Size = new System.Drawing.Size(118, 20);
            this.txtTenDK.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtTenDK, "Nhập tên đăng ký tài khoản");
            // 
            // lblMK
            // 
            this.lblMK.AutoSize = true;
            this.lblMK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMK.Location = new System.Drawing.Point(167, 132);
            this.lblMK.Name = "lblMK";
            this.lblMK.Size = new System.Drawing.Size(81, 16);
            this.lblMK.TabIndex = 24;
            this.lblMK.Text = "Mật khẩu (*):";
            // 
            // lblTenDK
            // 
            this.lblTenDK.AutoSize = true;
            this.lblTenDK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTenDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDK.Location = new System.Drawing.Point(167, 99);
            this.lblTenDK.Name = "lblTenDK";
            this.lblTenDK.Size = new System.Drawing.Size(102, 16);
            this.lblTenDK.TabIndex = 23;
            this.lblTenDK.Text = "Tên đăng ký (*):";
            // 
            // lblDangKy
            // 
            this.lblDangKy.AutoSize = true;
            this.lblDangKy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangKy.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDangKy.Location = new System.Drawing.Point(247, 20);
            this.lblDangKy.Name = "lblDangKy";
            this.lblDangKy.Size = new System.Drawing.Size(126, 29);
            this.lblDangKy.TabIndex = 22;
            this.lblDangKy.Text = "ĐĂNG KÝ";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangNhap.Location = new System.Drawing.Point(167, 249);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(106, 28);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.Gold;
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangKy.Location = new System.Drawing.Point(167, 203);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(253, 28);
            this.btnDangKy.TabIndex = 5;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // txtMKNL
            // 
            this.txtMKNL.Location = new System.Drawing.Point(302, 164);
            this.txtMKNL.Name = "txtMKNL";
            this.txtMKNL.PasswordChar = '*';
            this.txtMKNL.Size = new System.Drawing.Size(118, 20);
            this.txtMKNL.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtMKNL, "Nhập lại mật khẩu đăng ký tài khoản");
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(302, 60);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(118, 20);
            this.txtMaNV.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtMaNV, "Nhập mã nhân viên để đăng ký tài khoản");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nhập lại mật khẩu (*):";
            // 
            // pbeyeOpenMK
            // 
            this.pbeyeOpenMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbeyeOpenMK.Image = global::QLBH_MIEU.Properties.Resources.eyeOpen;
            this.pbeyeOpenMK.Location = new System.Drawing.Point(426, 128);
            this.pbeyeOpenMK.Name = "pbeyeOpenMK";
            this.pbeyeOpenMK.Size = new System.Drawing.Size(26, 19);
            this.pbeyeOpenMK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbeyeOpenMK.TabIndex = 31;
            this.pbeyeOpenMK.TabStop = false;
            this.pbeyeOpenMK.Click += new System.EventHandler(this.pbeyeOpenMK_Click);
            // 
            // pbeyeCloseMK
            // 
            this.pbeyeCloseMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbeyeCloseMK.Image = global::QLBH_MIEU.Properties.Resources.eyeClose;
            this.pbeyeCloseMK.Location = new System.Drawing.Point(426, 128);
            this.pbeyeCloseMK.Name = "pbeyeCloseMK";
            this.pbeyeCloseMK.Size = new System.Drawing.Size(26, 19);
            this.pbeyeCloseMK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbeyeCloseMK.TabIndex = 30;
            this.pbeyeCloseMK.TabStop = false;
            this.pbeyeCloseMK.Click += new System.EventHandler(this.pbeyeCloseMK_Click);
            // 
            // pbDangKy
            // 
            this.pbDangKy.Image = global::QLBH_MIEU.Properties.Resources.register;
            this.pbDangKy.Location = new System.Drawing.Point(12, 20);
            this.pbDangKy.Name = "pbDangKy";
            this.pbDangKy.Size = new System.Drawing.Size(137, 257);
            this.pbDangKy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDangKy.TabIndex = 27;
            this.pbDangKy.TabStop = false;
            // 
            // pbeyeCloseMKNL
            // 
            this.pbeyeCloseMKNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbeyeCloseMKNL.Image = global::QLBH_MIEU.Properties.Resources.eyeClose;
            this.pbeyeCloseMKNL.Location = new System.Drawing.Point(426, 164);
            this.pbeyeCloseMKNL.Name = "pbeyeCloseMKNL";
            this.pbeyeCloseMKNL.Size = new System.Drawing.Size(26, 19);
            this.pbeyeCloseMKNL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbeyeCloseMKNL.TabIndex = 32;
            this.pbeyeCloseMKNL.TabStop = false;
            this.pbeyeCloseMKNL.Click += new System.EventHandler(this.pbeyeCloseMKNL_Click);
            // 
            // pbeyeOpenMKNL
            // 
            this.pbeyeOpenMKNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbeyeOpenMKNL.Image = global::QLBH_MIEU.Properties.Resources.eyeOpen;
            this.pbeyeOpenMKNL.Location = new System.Drawing.Point(426, 164);
            this.pbeyeOpenMKNL.Name = "pbeyeOpenMKNL";
            this.pbeyeOpenMKNL.Size = new System.Drawing.Size(26, 19);
            this.pbeyeOpenMKNL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbeyeOpenMKNL.TabIndex = 33;
            this.pbeyeOpenMKNL.TabStop = false;
            this.pbeyeOpenMKNL.Click += new System.EventHandler(this.pbeyeOpenMKNL_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Location = new System.Drawing.Point(314, 249);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(106, 28);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(167, 65);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(106, 16);
            this.lblMaNV.TabIndex = 35;
            this.lblMaNV.Text = "Mã nhân viên (*):";
            // 
            // DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 292);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.pbeyeCloseMKNL);
            this.Controls.Add(this.pbeyeOpenMKNL);
            this.Controls.Add(this.pbeyeCloseMK);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.txtTenDK);
            this.Controls.Add(this.lblMK);
            this.Controls.Add(this.lblTenDK);
            this.Controls.Add(this.lblDangKy);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.pbeyeOpenMK);
            this.Controls.Add(this.txtMKNL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbDangKy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký";
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeOpenMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeCloseMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDangKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeCloseMKNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeyeOpenMKNL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtTenDK;
        private System.Windows.Forms.Label lblMK;
        private System.Windows.Forms.Label lblTenDK;
        private System.Windows.Forms.Label lblDangKy;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.TextBox txtMKNL;
        private System.Windows.Forms.PictureBox pbeyeOpenMK;
        private System.Windows.Forms.PictureBox pbeyeCloseMK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbDangKy;
        private System.Windows.Forms.PictureBox pbeyeCloseMKNL;
        private System.Windows.Forms.PictureBox pbeyeOpenMKNL;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMaNV;
    }
}