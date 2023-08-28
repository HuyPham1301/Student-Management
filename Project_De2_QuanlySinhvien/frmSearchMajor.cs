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
    public partial class frmSearchMajor : Form
    {
        MyTestContext context = new MyTestContext();
        public frmSearchMajor()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var load = (from c in context.Khoas
                        join s in context.SinhViens
                        on c.MaKhoa equals s.MaKhoa
                        where c.MaKhoa == cbCode.Text
                        select new
                        {
                            MaSo = s.MaSo,
                            HoTen = s.HoTen,
                            NgaySinh = s.NgaySinh,
                            GioiTinh = s.GioiTinh,
                            DiaChi = s.DiaChi,
                            DienThoai = s.DienThoai
                        }).ToList();
            dtgLoad.DataSource = load;
            dtgLoad.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void cbCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            var ten = (from c in context.Khoas
                       where c.MaKhoa == cbCode.Text
                       select c.TenKhoa).FirstOrDefault();
            txtName.Text = ten;
        }

        private void frmSearchMajor_Load(object sender, EventArgs e)
        {
            var ms = from c in context.Khoas
                     select c;
            cbCode.DataSource = ms.ToList();
            cbCode.DisplayMember = "MaKhoa";
        }
    }
}
