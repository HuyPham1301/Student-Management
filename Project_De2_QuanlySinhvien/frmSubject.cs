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

    public partial class frmSubject : Form
    {
        MyTestContext context = new MyTestContext();
        Validation va = new Validation();
        public frmSubject()
        {
            InitializeComponent();
        }

        private void frmSubject_Load(object sender, EventArgs e)
        {
            loadData();
            firstLoad();
        }

        private void loadData()
        {
            var load = (from c in context.Mons
                        join s in context.Khoas
                        on c.MaKhoa equals s.MaKhoa
                        select new
                        {
                            MaMon = c.MaMh,
                            TenMon = c.TenMh,
                            SoTiet = c.SoTiet,
                            Khoa = s.TenKhoa

                        }).ToList();
            dtgLoad.DataSource = load;
            dtgLoad.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            var data = context.Khoas.ToList();
            cbMajor.DataSource = data;
            cbMajor.DisplayMember = "TenKhoa";
            cbMajor.ValueMember = "MaKhoa";
        }

        private void firstLoad()
        {
            dtgLoad.Rows[0].Selected = true;
            txtCode.Text = dtgLoad.CurrentRow.Cells["MaMon"].FormattedValue.ToString();
            txtName.Text = dtgLoad.CurrentRow.Cells["TenMon"].FormattedValue.ToString();
            txtSlot.Text = dtgLoad.CurrentRow.Cells["SoTiet"].FormattedValue.ToString();
            cbMajor.Text = dtgLoad.CurrentRow.Cells["Khoa"].FormattedValue.ToString();
        }

        private void dtgLoad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCode.ReadOnly = true;
            if (e.RowIndex == -1) return;
            txtCode.Text = dtgLoad.CurrentRow.Cells["MaMon"].FormattedValue.ToString();
            txtName.Text = dtgLoad.CurrentRow.Cells["TenMon"].FormattedValue.ToString();
            txtSlot.Text = dtgLoad.CurrentRow.Cells["SoTiet"].FormattedValue.ToString();
            cbMajor.Text = dtgLoad.CurrentRow.Cells["Khoa"].FormattedValue.ToString();
        }

        private bool isCodeExist(string code)
        {
            Mon sv = context.Mons.Where(x => x.MaMh.ToLower() == code.ToLower()).FirstOrDefault();
            if (sv != null)
            {
                return true;
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Chưa nhập Mã môn học");
                return;
            }
            else if (isCodeExist(txtCode.Text))
            {
                MessageBox.Show("Mã môn học " + txtCode.Text + " đã tồn tại!");
                return;
            }
            else if(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtSlot.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin Môn học");
                return;
            }
            if (va.checkInt(txtSlot.Text))
            {
                Mon m = new Mon();
                m.MaMh = txtCode.Text;
                m.TenMh = txtName.Text;
                m.SoTiet = Convert.ToInt32(txtSlot.Text);
                m.MaKhoa = cbMajor.SelectedValue.ToString();
                context.Mons.Add(m);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Thêm môn học thành công");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Thêm môn học lỗi!");
                }
            }
            else
            {
                MessageBox.Show("Kiểu dữ liệu của số tiết không đúng!");

            }
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Chưa nhập Mã môn học");
                return;
            }
            else if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtSlot.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin Môn học");
                return;
            }

            Mon m = context.Mons.Where(c => c.MaMh.ToLower().Equals(txtCode.Text.ToLower())).FirstOrDefault();
            if(m == null)
            {
                MessageBox.Show("Mã môn học không tồn tại");
                return;
            }
            if (va.checkInt(txtSlot.Text))
            {
                m.TenMh = txtName.Text;
                m.SoTiet = Convert.ToInt32(txtSlot.Text);
                m.MaKhoa = cbMajor.SelectedValue.ToString();
                int i = context.SaveChanges();
                if (i > 0)
                {
                    MessageBox.Show("Cập nhật môn học thành công");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Thông tin môn học không có gì thay đổi!");
                }
            }
            else
            {
                MessageBox.Show("Nhập sai kiểu dữ liệu Số tiết");
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var sv = context.KetQuas.Where(s => s.MaMh.ToLower().Equals(txtCode.Text.ToLower())).FirstOrDefault();
            if (sv != null)
            {
                MessageBox.Show("Xoá lỗi FK");
                return;
            }
            Mon m = context.Mons.Where(c => c.MaMh.ToLower().Equals(txtCode.Text.ToLower())).FirstOrDefault();
            context.Mons.Remove(m);
            if (context.SaveChanges() > 0)
            {
                MessageBox.Show("Xoá môn học thành công");
                loadData();
            }
            else
            {
                MessageBox.Show("Xoá môn học lỗi!");
            }
        }

        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCode.ReadOnly = false;
        }
    }
}
