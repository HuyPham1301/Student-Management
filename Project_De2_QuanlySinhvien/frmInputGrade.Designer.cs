namespace Project_De2_QuanlySinhvien
{
    partial class frmInputGrade
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCode = new System.Windows.Forms.ComboBox();
            this.cbSubjectCode = new System.Windows.Forms.ComboBox();
            this.txtMark = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMon = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã số";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã môn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên môn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Điểm";
            // 
            // cbCode
            // 
            this.cbCode.FormattingEnabled = true;
            this.cbCode.Location = new System.Drawing.Point(180, 31);
            this.cbCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(133, 23);
            this.cbCode.TabIndex = 5;
            this.cbCode.SelectedIndexChanged += new System.EventHandler(this.cbCode_SelectedIndexChanged);
            // 
            // cbSubjectCode
            // 
            this.cbSubjectCode.FormattingEnabled = true;
            this.cbSubjectCode.Location = new System.Drawing.Point(180, 142);
            this.cbSubjectCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSubjectCode.Name = "cbSubjectCode";
            this.cbSubjectCode.Size = new System.Drawing.Size(133, 23);
            this.cbSubjectCode.TabIndex = 7;
            this.cbSubjectCode.SelectedIndexChanged += new System.EventHandler(this.cbSubjectCode_SelectedIndexChanged);
            // 
            // txtMark
            // 
            this.txtMark.Location = new System.Drawing.Point(180, 265);
            this.txtMark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(133, 23);
            this.txtMark.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(298, 320);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 22);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Nhập";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(180, 81);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(232, 23);
            this.txtName.TabIndex = 11;
            // 
            // txtMon
            // 
            this.txtMon.Location = new System.Drawing.Point(180, 203);
            this.txtMon.Name = "txtMon";
            this.txtMon.ReadOnly = true;
            this.txtMon.Size = new System.Drawing.Size(232, 23);
            this.txtMon.TabIndex = 12;
            // 
            // frmInputGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 362);
            this.Controls.Add(this.txtMon);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMark);
            this.Controls.Add(this.cbSubjectCode);
            this.Controls.Add(this.cbCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmInputGrade";
            this.Text = "Nhập Điểm";
            this.Load += new System.EventHandler(this.frmInputGrade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCode;
        private System.Windows.Forms.ComboBox cbSubjectCode;
        private System.Windows.Forms.TextBox txtMark;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMon;
    }
}