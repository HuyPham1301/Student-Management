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
    public partial class frmViewGrade : Form
    {
        MyTestContext context = new MyTestContext();
        public frmViewGrade()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var load = (from c in context.KetQuas
                        join m in context.Mons
                        on c.MaMh equals m.MaMh
                        where c.MaSo == cbCode.Text
                        select new
                        {
                            TenMH = m.TenMh,
                            Diem = c.Diem
                        }).ToList();
            dtgLoad.DataSource = load;
            dtgLoad.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmViewGrade_Load(object sender, EventArgs e)
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

            var khoa = (from c in context.SinhViens
                        where c.MaSo == cbCode.Text
                        select c.MaKhoa).FirstOrDefault();
            txtMajor.Text = khoa;
        }
    }
}
