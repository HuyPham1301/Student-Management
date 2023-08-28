using System;
using System.Collections.Generic;

#nullable disable

namespace Project_De2_QuanlySinhvien.Models
{
    public partial class Khoa
    {
        public Khoa()
        {
            Mons = new HashSet<Mon>();
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }

        public virtual ICollection<Mon> Mons { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
