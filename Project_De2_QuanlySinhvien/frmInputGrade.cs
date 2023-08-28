using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_De2_QuanlySinhvien.Models;

namespace Project_De2_QuanlySinhvien
{
    public partial class frmInputGrade : Form
    {
        MyTestContext context = new MyTestContext();
        Validation va = new Validation();
        public frmInputGrade()
        {
            InitializeComponent();
        }

        private void frmInputGrade_Load(object sender, EventArgs e)
        {
            var ms = from c in context.SinhViens
                     select c.MaSo;
            cbCode.DataSource = ms.ToList();
            cbCode.DisplayMember = "MaSo";
        }

        private void cbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ten = (from c in context.SinhViens
                       where c.MaSo == cbCode.Text
                       select c.HoTen).FirstOrDefault();
            txtName.Text = ten;

            var mon = (from s in context.SinhViens
                       join k in context.Khoas
                       on s.MaKhoa equals k.MaKhoa
                       join m in context.Mons
                       on k.MaKhoa equals m.MaKhoa
                       where s.MaSo == cbCode.Text
                       select m.MaMh
                        ).ToList();
            cbSubjectCode.DataSource = mon;
            var ketqua = (from c in context.KetQuas
                          where c.MaSo == cbCode.Text && c.MaMh == cbSubjectCode.Text
                          select c.Diem).FirstOrDefault();
            txtMark.Text = ketqua.ToString();
            if (!String.IsNullOrEmpty(txtMark.Text))
            {
                btnAdd.Text = "Cập nhật điểm";
            }
            else
            {
                btnAdd.Text = "Nhập điểm";
            }
        }

        private void cbSubjectCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ten = (from c in context.Mons
                       where c.MaMh == cbSubjectCode.Text
                       select c.TenMh).FirstOrDefault();
            txtMon.Text = ten;

            var ketqua = (from c in context.KetQuas
                          where c.MaSo == cbCode.Text && c.MaMh == cbSubjectCode.Text
                          select c.Diem).FirstOrDefault();
            txtMark.Text = ketqua.ToString();
            if (!String.IsNullOrEmpty(txtMark.Text))
            {
                btnAdd.Text = "Cập nhật điểm";
            }
            else
            {
                btnAdd.Text = "Nhập điểm";
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var ketqua = (from c in context.KetQuas
                          where c.MaSo == cbCode.Text && c.MaMh == cbSubjectCode.Text
                          select c.Diem).FirstOrDefault();


            if (ketqua == null)
            {
                if (String.IsNullOrEmpty(txtMark.Text))
                {
                    MessageBox.Show("Chưa nhập điểm!");
                }
                else
                {
                    if (va.checkDecimal(txtMark.Text))
                    {
                        KetQua k = new KetQua();
                        k.MaSo = cbCode.Text.ToUpper();
                        k.MaMh = cbSubjectCode.Text;
                        k.Diem = decimal.Parse(txtMark.Text);
                        context.KetQuas.Add(k);
                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Nhập điểm thành công cho Sinh viên " + txtName.Text + " môn " + txtMon.Text);
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập sai kiểu dữ liệu cho điểm");
                    }
                }

            }
            else
            {
                if (va.checkDecimal(txtMark.Text))
                {
                    KetQua k = (from v in context.KetQuas
                                where v.MaSo == cbCode.Text && v.MaMh == cbSubjectCode.Text
                                select v).FirstOrDefault();
                    k.Diem = decimal.Parse(txtMark.Text);

                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Cập nhật điểm thành công cho Sinh viên " + txtName.Text + " môn " + txtMon.Text);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sự thay đổi. Điểm số được giữ nguyên");
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai kiểu dữ liệu cho điểm");
                }

            }
        }
    }
}
