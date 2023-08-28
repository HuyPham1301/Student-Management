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
    public partial class frmMajor : Form
    {
        MyTestContext context = new MyTestContext();
        public frmMajor()
        {
            InitializeComponent();
        }

        private void frmMajor_Load(object sender, EventArgs e)
        {
            loadData();
            firstLoad();

        }

        private void firstLoad()
        {
            dtgLoad.Rows[0].Selected = true;
            txtCode.Text = dtgLoad.CurrentRow.Cells["MaKhoa"].FormattedValue.ToString();
            txtName.Text = dtgLoad.CurrentRow.Cells["TenKhoa"].FormattedValue.ToString();

        }

        private void loadData()
        {
            var load = (from c in context.Khoas

                        select new
                        {
                            Makhoa = c.MaKhoa,
                            TenKhoa = c.TenKhoa,
                        }).ToList();
            dtgLoad.DataSource = load;
            dtgLoad.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isCodeExisted(txtCode.Text))
            {
                MessageBox.Show("Mã khoa " + txtCode.Text.Trim() + " đã tồn tại!");
                return;
            }
            else if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Chưa nhập mã khoa");
                return;
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Chưa nhập tên khoa");
                return;
            }
            Khoa k = new Khoa();
            k.MaKhoa = txtCode.Text;
            k.TenKhoa = txtName.Text;
            context.Khoas.Add(k);
            if (context.SaveChanges() > 0)
            {
                MessageBox.Show("Thêm chuyên ngành thành công");
                loadData();
            }
            else
            {
                MessageBox.Show("Thêm chuyên ngành lỗi!");
            }

        }

        private bool isCodeExisted(string code)
        {
            var list = context.Khoas.ToList();
            foreach (Khoa c in list)
            {
                if (c.MaKhoa.ToLower().Equals(code.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Khoa k = context.Khoas.Where(c => c.MaKhoa.ToLower().Equals(txtCode.Text.ToLower())).FirstOrDefault();
            if (k != null)
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Chưa nhập tên khoa");
                    return;
                }
                k.TenKhoa = txtName.Text;
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Cập nhật chuyên ngành thành công");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật chuyên ngành lỗi!");
                }
            }
            else
            {
                MessageBox.Show("Mã khoa " + txtCode.Text + " không tồn tại");
            }


        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            var sv = context.SinhViens.Where(s => s.MaKhoa.ToLower().Equals(txtCode.Text.ToLower())).FirstOrDefault();
            if (sv != null)
            {
                MessageBox.Show("Chuyên ngành vẫn còn học viên theo học");
                return;
            }
            Khoa k = context.Khoas.Where(c => c.MaKhoa.ToLower().Equals(txtCode.Text.ToLower())).FirstOrDefault();
            context.Khoas.Remove(k);
            if (context.SaveChanges() > 0)
            {
                MessageBox.Show("Xoá chuyên ngành thành công");
                loadData();
            }
            else
            {
                MessageBox.Show("Xoá chuyên ngành lỗi");
            }
        }

        private void dtgLoad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCode.ReadOnly = true;
            if (e.RowIndex == -1) return;
            txtCode.Text = dtgLoad.CurrentRow.Cells["MaKhoa"].FormattedValue.ToString();
            txtName.Text = dtgLoad.CurrentRow.Cells["TenKhoa"].FormattedValue.ToString();
        }

        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCode.ReadOnly = false;
        }
    }
}
