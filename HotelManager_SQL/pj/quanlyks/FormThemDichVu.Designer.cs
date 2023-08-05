
namespace quanlyks
{
    partial class FormThemDichVu
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
            this.lbFormName = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.lbMaDV = new System.Windows.Forms.Label();
            this.lbMaPDP = new System.Windows.Forms.Label();
            this.cbMaPDP = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvListDV = new System.Windows.Forms.DataGridView();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lbDonGia = new System.Windows.Forms.Label();
            this.dgvCTDV = new System.Windows.Forms.DataGridView();
            this.btnCapNhatDV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHDDV = new System.Windows.Forms.TextBox();
            this.btnXoaDV = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDV)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFormName
            // 
            this.lbFormName.AutoSize = true;
            this.lbFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFormName.Location = new System.Drawing.Point(342, 20);
            this.lbFormName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFormName.Name = "lbFormName";
            this.lbFormName.Size = new System.Drawing.Size(144, 24);
            this.lbFormName.TabIndex = 0;
            this.lbFormName.Text = "Thêm Dịch Vụ";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Location = new System.Drawing.Point(28, 198);
            this.lbSoLuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(52, 13);
            this.lbSoLuong.TabIndex = 1;
            this.lbSoLuong.Text = "Số lượng:";
            // 
            // lbMaDV
            // 
            this.lbMaDV.AutoSize = true;
            this.lbMaDV.Location = new System.Drawing.Point(28, 124);
            this.lbMaDV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMaDV.Name = "lbMaDV";
            this.lbMaDV.Size = new System.Drawing.Size(47, 13);
            this.lbMaDV.TabIndex = 2;
            this.lbMaDV.Text = "Dịch vụ:";
            // 
            // lbMaPDP
            // 
            this.lbMaPDP.AutoSize = true;
            this.lbMaPDP.Location = new System.Drawing.Point(28, 87);
            this.lbMaPDP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMaPDP.Name = "lbMaPDP";
            this.lbMaPDP.Size = new System.Drawing.Size(77, 13);
            this.lbMaPDP.TabIndex = 3;
            this.lbMaPDP.Text = "Mã đặt phòng:";
            // 
            // cbMaPDP
            // 
            this.cbMaPDP.FormattingEnabled = true;
            this.cbMaPDP.Location = new System.Drawing.Point(124, 87);
            this.cbMaPDP.Margin = new System.Windows.Forms.Padding(2);
            this.cbMaPDP.Name = "cbMaPDP";
            this.cbMaPDP.Size = new System.Drawing.Size(92, 21);
            this.cbMaPDP.TabIndex = 4;
            this.cbMaPDP.SelectedIndexChanged += new System.EventHandler(this.cbMaPDP_SelectedIndexChanged);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(124, 198);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(92, 20);
            this.txtSoLuong.TabIndex = 6;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(23, 275);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 24);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvListDV
            // 
            this.dgvListDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListDV.ColumnHeadersHeight = 29;
            this.dgvListDV.Location = new System.Drawing.Point(246, 76);
            this.dgvListDV.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListDV.Name = "dgvListDV";
            this.dgvListDV.RowHeadersWidth = 51;
            this.dgvListDV.RowTemplate.Height = 24;
            this.dgvListDV.Size = new System.Drawing.Size(535, 100);
            this.dgvListDV.TabIndex = 8;
            this.dgvListDV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListDV_CellClick);
            // 
            // txtMaDV
            // 
            this.txtMaDV.Location = new System.Drawing.Point(124, 124);
            this.txtMaDV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.Size = new System.Drawing.Size(92, 20);
            this.txtMaDV.TabIndex = 9;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(124, 161);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(92, 20);
            this.txtDonGia.TabIndex = 11;
            // 
            // lbDonGia
            // 
            this.lbDonGia.AutoSize = true;
            this.lbDonGia.Location = new System.Drawing.Point(28, 161);
            this.lbDonGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDonGia.Name = "lbDonGia";
            this.lbDonGia.Size = new System.Drawing.Size(47, 13);
            this.lbDonGia.TabIndex = 10;
            this.lbDonGia.Text = "Đơn giá:";
            // 
            // dgvCTDV
            // 
            this.dgvCTDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTDV.ColumnHeadersHeight = 29;
            this.dgvCTDV.Location = new System.Drawing.Point(246, 220);
            this.dgvCTDV.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCTDV.Name = "dgvCTDV";
            this.dgvCTDV.RowHeadersWidth = 51;
            this.dgvCTDV.RowTemplate.Height = 24;
            this.dgvCTDV.Size = new System.Drawing.Size(535, 154);
            this.dgvCTDV.TabIndex = 14;
            this.dgvCTDV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTDV_CellClick);
            // 
            // btnCapNhatDV
            // 
            this.btnCapNhatDV.Location = new System.Drawing.Point(134, 275);
            this.btnCapNhatDV.Margin = new System.Windows.Forms.Padding(2);
            this.btnCapNhatDV.Name = "btnCapNhatDV";
            this.btnCapNhatDV.Size = new System.Drawing.Size(80, 24);
            this.btnCapNhatDV.TabIndex = 15;
            this.btnCapNhatDV.Text = "Cập nhật";
            this.btnCapNhatDV.UseVisualStyleBackColor = true;
            this.btnCapNhatDV.Click += new System.EventHandler(this.btnCapNhatDV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Các dịch vụ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Chi tiết dịch vụ:";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtThanhTien.Location = new System.Drawing.Point(124, 235);
            this.txtThanhTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(92, 20);
            this.txtThanhTien.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 235);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Thành Tiền:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(549, 392);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Tổng hóa đơn dịch vụ:";
            // 
            // txtHDDV
            // 
            this.txtHDDV.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHDDV.Location = new System.Drawing.Point(689, 388);
            this.txtHDDV.Margin = new System.Windows.Forms.Padding(2);
            this.txtHDDV.Name = "txtHDDV";
            this.txtHDDV.Size = new System.Drawing.Size(92, 20);
            this.txtHDDV.TabIndex = 18;
            // 
            // btnXoaDV
            // 
            this.btnXoaDV.Location = new System.Drawing.Point(80, 318);
            this.btnXoaDV.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaDV.Name = "btnXoaDV";
            this.btnXoaDV.Size = new System.Drawing.Size(80, 24);
            this.btnXoaDV.TabIndex = 20;
            this.btnXoaDV.Text = "Xóa";
            this.btnXoaDV.UseVisualStyleBackColor = true;
            this.btnXoaDV.Click += new System.EventHandler(this.btnXoaDV_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(80, 358);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(80, 26);
            this.btnReturn.TabIndex = 48;
            this.btnReturn.Text = "Quay lại";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // FormThemDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 417);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnXoaDV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHDDV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCapNhatDV);
            this.Controls.Add(this.dgvCTDV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.lbDonGia);
            this.Controls.Add(this.txtMaDV);
            this.Controls.Add(this.dgvListDV);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.cbMaPDP);
            this.Controls.Add(this.lbMaPDP);
            this.Controls.Add(this.lbMaDV);
            this.Controls.Add(this.lbSoLuong);
            this.Controls.Add(this.lbFormName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormThemDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormThemDichVu";
            this.Load += new System.EventHandler(this.FormThemDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFormName;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.Label lbMaDV;
        private System.Windows.Forms.Label lbMaPDP;
        private System.Windows.Forms.ComboBox cbMaPDP;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvListDV;
        private System.Windows.Forms.TextBox txtMaDV;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lbDonGia;
        private System.Windows.Forms.DataGridView dgvCTDV;
        private System.Windows.Forms.Button btnCapNhatDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHDDV;
        private System.Windows.Forms.Button btnXoaDV;
        private System.Windows.Forms.Button btnReturn;
    }
}