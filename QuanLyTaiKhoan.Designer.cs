namespace QLBH_MIEU
{
    partial class QuanLyTaiKhoan
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
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.dgvTK = new System.Windows.Forms.DataGridView();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTuKhoaTK = new System.Windows.Forms.TextBox();
            this.lblTuKhoaTK = new System.Windows.Forms.Label();
            this.gbChucNang = new System.Windows.Forms.GroupBox();
            this.pbXoa = new System.Windows.Forms.PictureBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblQLTK = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pbLOGO = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).BeginInit();
            this.gbTimKiem.SuspendLayout();
            this.gbChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTrangChu.BackColor = System.Drawing.Color.GreenYellow;
            this.btnTrangChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.ForeColor = System.Drawing.Color.Black;
            this.btnTrangChu.Location = new System.Drawing.Point(22, 544);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(92, 28);
            this.btnTrangChu.TabIndex = 4;
            this.btnTrangChu.Text = "Trang chủ";
            this.toolTip1.SetToolTip(this.btnTrangChu, "Quay về trang chủ");
            this.btnTrangChu.UseVisualStyleBackColor = false;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // dgvTK
            // 
            this.dgvTK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTK.Location = new System.Drawing.Point(22, 289);
            this.dgvTK.Name = "dgvTK";
            this.dgvTK.Size = new System.Drawing.Size(611, 239);
            this.dgvTK.TabIndex = 132;
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbTimKiem.Controls.Add(this.btnTimKiem);
            this.gbTimKiem.Controls.Add(this.txtTuKhoaTK);
            this.gbTimKiem.Controls.Add(this.lblTuKhoaTK);
            this.gbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTimKiem.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.gbTimKiem.Location = new System.Drawing.Point(22, 56);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(611, 84);
            this.gbTimKiem.TabIndex = 131;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.LightPink;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Location = new System.Drawing.Point(533, 39);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(65, 23);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTuKhoaTK
            // 
            this.txtTuKhoaTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuKhoaTK.Location = new System.Drawing.Point(154, 39);
            this.txtTuKhoaTK.Name = "txtTuKhoaTK";
            this.txtTuKhoaTK.Size = new System.Drawing.Size(359, 24);
            this.txtTuKhoaTK.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtTuKhoaTK, "Nhập từ khóa tìm kiếm");
            this.txtTuKhoaTK.TextChanged += new System.EventHandler(this.txtTuKhoaTK_TextChanged);
            // 
            // lblTuKhoaTK
            // 
            this.lblTuKhoaTK.AutoSize = true;
            this.lblTuKhoaTK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTuKhoaTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuKhoaTK.ForeColor = System.Drawing.Color.Black;
            this.lblTuKhoaTK.Location = new System.Drawing.Point(22, 43);
            this.lblTuKhoaTK.Name = "lblTuKhoaTK";
            this.lblTuKhoaTK.Size = new System.Drawing.Size(112, 16);
            this.lblTuKhoaTK.TabIndex = 61;
            this.lblTuKhoaTK.Text = "Từ khóa tìm kiếm:";
            // 
            // gbChucNang
            // 
            this.gbChucNang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbChucNang.Controls.Add(this.pbXoa);
            this.gbChucNang.Controls.Add(this.btnXoa);
            this.gbChucNang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbChucNang.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.gbChucNang.Location = new System.Drawing.Point(22, 159);
            this.gbChucNang.Name = "gbChucNang";
            this.gbChucNang.Size = new System.Drawing.Size(611, 107);
            this.gbChucNang.TabIndex = 135;
            this.gbChucNang.TabStop = false;
            this.gbChucNang.Text = "Chức năng";
            // 
            // pbXoa
            // 
            this.pbXoa.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbXoa.Image = global::QLBH_MIEU.Properties.Resources.delete;
            this.pbXoa.Location = new System.Drawing.Point(38, 28);
            this.pbXoa.Name = "pbXoa";
            this.pbXoa.Size = new System.Drawing.Size(96, 24);
            this.pbXoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbXoa.TabIndex = 69;
            this.pbXoa.TabStop = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(38, 58);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 28);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lblQLTK
            // 
            this.lblQLTK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblQLTK.AutoSize = true;
            this.lblQLTK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQLTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQLTK.ForeColor = System.Drawing.Color.Crimson;
            this.lblQLTK.Location = new System.Drawing.Point(193, 15);
            this.lblQLTK.Name = "lblQLTK";
            this.lblQLTK.Size = new System.Drawing.Size(268, 29);
            this.lblQLTK.TabIndex = 129;
            this.lblQLTK.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.Location = new System.Drawing.Point(549, 544);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 28);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pbLOGO
            // 
            this.pbLOGO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbLOGO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLOGO.ErrorImage = null;
            this.pbLOGO.Image = global::QLBH_MIEU.Properties.Resources.LOGO_MIEU;
            this.pbLOGO.Location = new System.Drawing.Point(22, 15);
            this.pbLOGO.Name = "pbLOGO";
            this.pbLOGO.Size = new System.Drawing.Size(32, 29);
            this.pbLOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLOGO.TabIndex = 133;
            this.pbLOGO.TabStop = false;
            this.pbLOGO.Click += new System.EventHandler(this.pbLOGO_Click);
            // 
            // QuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 586);
            this.Controls.Add(this.btnTrangChu);
            this.Controls.Add(this.pbLOGO);
            this.Controls.Add(this.dgvTK);
            this.Controls.Add(this.gbTimKiem);
            this.Controls.Add(this.gbChucNang);
            this.Controls.Add(this.lblQLTK);
            this.Controls.Add(this.btnThoat);
            this.Name = "QuanLyTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Tài Khoản";
            this.Load += new System.EventHandler(this.QuanLyTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).EndInit();
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.gbChucNang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLOGO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.PictureBox pbLOGO;
        private System.Windows.Forms.DataGridView dgvTK;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.TextBox txtTuKhoaTK;
        private System.Windows.Forms.Label lblTuKhoaTK;
        private System.Windows.Forms.GroupBox gbChucNang;
        private System.Windows.Forms.PictureBox pbXoa;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblQLTK;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}