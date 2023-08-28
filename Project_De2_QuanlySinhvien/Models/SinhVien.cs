using System;
using System.Collections.Generic;

#nullable disable

namespace Project_De2_QuanlySinhvien.Models
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            KetQuas = new HashSet<KetQua>();
        }

        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool? GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string MaKhoa { get; set; }
        public bool? Status { get; set; }

        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
