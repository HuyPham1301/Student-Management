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

    public partial class frmStudent : Form
    {
        MyTestContext context = new MyTestContext();
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            // loadData();
            designDGV();
            //firstLoad();
        }

        private void loadData()
        {
            var load = (from c in context.Khoas
                        join s in context.SinhViens
                        on c.MaKhoa equals s.MaKhoa
                        select new
                        {
                            MaSo = s.MaSo,
                            HoTen = s.HoTen,
                            Khoa = c.TenKhoa,
                            NgaySinh = s.NgaySinh,
                            GioiTinh = s.GioiTinh,
                            DienThoai = s.DienThoai,
                            DiaChi = s.DiaChi,
                        }).ToList();
            dtgLoad.DataSource = load;
            dtgLoad.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            var data = context.Khoas.ToList();
            cbKhoa.DataSource = data;
            cbKhoa.DisplayMember = "TenKhoa";
            cbKhoa.ValueMember = "MaKhoa";


        }

        private void designDGV()
        {
            var load = (from c in context.Khoas
                        join s in context.SinhViens
                        on c.MaKhoa equals s.MaKhoa
                        select new
                        {
                            MaSo = s.MaSo,
                            HoTen = s.HoTen,
                            Khoa = c.TenKhoa,
                            NgaySinh = s.NgaySinh,
                            GioiTinh = s.GioiTinh,
                            DienThoai = s.DienThoai,
                            DiaChi = s.DiaChi,
                        }).ToList();

            dtgLoad.AutoGenerateColumns = false;
            dtgLoad.DataSource = load;
            //dtgLoad.ReadOnly = true;
            dtgLoad.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaSo",
                Name = "MaSo",
            });
            dtgLoad.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HoTen",
                Name = "HoTen",
            });
            dtgLoad.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NgaySinh",
                Name = "NgaySinh",
            });
            dtgLoad.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "GioiTinh",
                Name = "GioiTinh",
            });
            dtgLoad.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DiaChi",
                Name = "DiaChi",
            });
            dtgLoad.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DienThoai",
                Name = "DienThoai",
            });
            dtgLoad.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Khoa",
                Name = "Khoa",
            });

            dtgLoad.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            var data = context.Khoas.ToList();
            cbKhoa.DataSource = data;
            cbKhoa.DisplayMember = "TenKhoa";
            cbKhoa.ValueMember = "MaKhoa";

        }

        private void firstLoad()
        {
            dtgLoad.Rows[0].Selected = true;
            txtCode.Text = dtgLoad.CurrentRow.Cells["MaSo"].FormattedValue.ToString();
            txtName.Text = dtgLoad.CurrentRow.Cells["HoTen"].FormattedValue.ToString();
            datetimePicker.Value = DateTime.Parse(dtgLoad.CurrentRow.Cells["NgaySinh"].FormattedValue.ToString());
            rFemale.Checked = true;
            bool gender = bool.Parse(dtgLoad.CurrentRow.Cells["GioiTinh"].FormattedValue.ToString());
            if (gender == true)
            {
                rMale.Checked = true;
            }
            txtAddress.Text = dtgLoad.CurrentRow.Cells["DiaChi"].FormattedValue.ToString();
            txtPhone.Text = dtgLoad.CurrentRow.Cells["DienThoai"].FormattedValue.ToString();
            cbKhoa.Text = dtgLoad.CurrentRow.Cells["Khoa"].FormattedValue.ToString();

        }

        private void dtgLoad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCode.ReadOnly = true;
            if (e.RowIndex == -1) return;
            txtCode.Text = dtgLoad.CurrentRow.Cells["MaSo"].FormattedValue.ToString();
            txtName.Text = dtgLoad.CurrentRow.Cells["HoTen"].FormattedValue.ToString();
            datetimePicker.Value = DateTime.Parse(dtgLoad.CurrentRow.Cells["NgaySinh"].FormattedValue.ToString());
            rFemale.Checked = true;
            bool gender = bool.Parse(dtgLoad.CurrentRow.Cells["GioiTinh"].FormattedValue.ToString());
            if (gender == true)
            {
                rMale.Checked = true;
            }
            txtAddress.Text = dtgLoad.CurrentRow.Cells["DiaChi"].FormattedValue.ToString();
            txtPhone.Text = dtgLoad.CurrentRow.Cells["DienThoai"].FormattedValue.ToString();
            cbKhoa.Text = dtgLoad.CurrentRow.Cells["Khoa"].FormattedValue.ToString();

        }
        private bool isCodeExist(string code)
        {
            SinhVien sv = context.SinhViens.Where(x => x.MaSo.ToLower() == code.ToLower()).FirstOrDefault();
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
                MessageBox.Show("Chưa nhập MSSV");
                return;
            }
            else if (isCodeExist(txtCode.Text))
            {
                MessageBox.Show("Mã số sinh viên " + txtCode.Text + " đã tồn tại!");
                return;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin sinh viên");
                return;
            }
            SinhVien sv = new SinhVien();
            sv.MaSo = txtCode.Text.ToUpper();
            sv.HoTen = txtName.Text;
            sv.NgaySinh = datetimePicker.Value;
            bool gender = true;
            if (rFemale.Checked)
            {
                gender = false;
            }
            sv.GioiTinh = gender;
            sv.DiaChi = txtAddress.Text;
            sv.DienThoai = txtPhone.Text;
            sv.MaKhoa = cbKhoa.SelectedValue.ToString();
            context.SinhViens.Add(sv);
            if (context.SaveChanges() > 0)
            {
                MessageBox.Show("Thêm sinh viên thành công");
                loadData();
            }
            else
            {
                MessageBox.Show("Thêm sinh viên lỗi!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            SinhVien sv = context.SinhViens.Where(s => s.MaSo == txtCode.Text).FirstOrDefault();
            if (sv == null)
            {
                MessageBox.Show("Mã số sinh viên không tồn tại!");
                return;

            }
            else if (string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin sinh viên");
                return;
            }
            sv.HoTen = txtName.Text;
            sv.NgaySinh = datetimePicker.Value;
            bool gender = true;
            if (rFemale.Checked)
            {
                gender = false;
            }
            sv.GioiTinh = gender;
            sv.DiaChi = txtAddress.Text;
            sv.DienThoai = txtPhone.Text;
            sv.MaKhoa = cbKhoa.SelectedValue.ToString();
            if (context.SaveChanges() > 0)
            {
                MessageBox.Show("Cập nhật thông tin sinh viên thành công");
                loadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin sinh viên lỗi!");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var v = context.KetQuas.Where(s => s.MaSo == txtCode.Text).FirstOrDefault();
            SinhVien sv = context.SinhViens.Where(s => s.MaSo == txtCode.Text).FirstOrDefault();
            if (v != null)
            {

                MessageBox.Show("Xoá sinh viên lỗi FK");
                return;
            }

            context.SinhViens.Remove(sv);
            if (context.SaveChanges() > 0)
            {
                MessageBox.Show("Xoá sinh viên thành công");
                loadData();
            }
            else
            {
                MessageBox.Show("Xoá sinh viên lỗi!");
            }
        }

        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCode.ReadOnly = false;
        }



    }
}
