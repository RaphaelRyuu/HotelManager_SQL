
namespace quanlyks
{
    partial class FormLoaiPhong
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
            this.lbMaLP = new System.Windows.Forms.Label();
            this.lbTenLoai = new System.Windows.Forms.Label();
            this.txtMaLoaiPhong = new System.Windows.Forms.TextBox();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.lbFormName = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMaLP
            // 
            this.lbMaLP.AutoSize = true;
            this.lbMaLP.Location = new System.Drawing.Point(50, 91);
            this.lbMaLP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMaLP.Name = "lbMaLP";
            this.lbMaLP.Size = new System.Drawing.Size(82, 13);
            this.lbMaLP.TabIndex = 0;
            this.lbMaLP.Text = "Mã Loại Phòng:";
            // 
            // lbTenLoai
            // 
            this.lbTenLoai.AutoSize = true;
            this.lbTenLoai.Location = new System.Drawing.Point(50, 140);
            this.lbTenLoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTenLoai.Name = "lbTenLoai";
            this.lbTenLoai.Size = new System.Drawing.Size(48, 13);
            this.lbTenLoai.TabIndex = 1;
            this.lbTenLoai.Text = "Tên loại:";
            // 
            // txtMaLoaiPhong
            // 
            this.txtMaLoaiPhong.Location = new System.Drawing.Point(157, 91);
            this.txtMaLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaLoaiPhong.Name = "txtMaLoaiPhong";
            this.txtMaLoaiPhong.Size = new System.Drawing.Size(128, 20);
            this.txtMaLoaiPhong.TabIndex = 2;
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.Location = new System.Drawing.Point(157, 140);
            this.txtTenLoai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(128, 20);
            this.txtTenLoai.TabIndex = 3;
            // 
            // lbFormName
            // 
            this.lbFormName.AutoSize = true;
            this.lbFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFormName.Location = new System.Drawing.Point(115, 41);
            this.lbFormName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFormName.Name = "lbFormName";
            this.lbFormName.Size = new System.Drawing.Size(116, 24);
            this.lbFormName.TabIndex = 4;
            this.lbFormName.Text = "Loại Phòng";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(132, 199);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(81, 26);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(132, 239);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(81, 26);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "Quay lại";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // FormLoaiPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 300);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lbFormName);
            this.Controls.Add(this.txtTenLoai);
            this.Controls.Add(this.txtMaLoaiPhong);
            this.Controls.Add(this.lbTenLoai);
            this.Controls.Add(this.lbMaLP);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormLoaiPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLoaiPhong";
            this.Load += new System.EventHandler(this.FormLoaiPhong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMaLP;
        private System.Windows.Forms.Label lbTenLoai;
        private System.Windows.Forms.TextBox txtMaLoaiPhong;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.Label lbFormName;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnReturn;
    }
}