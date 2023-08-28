using System;
using System.Collections.Generic;

#nullable disable

namespace Project_De2_QuanlySinhvien.Models
{
    public partial class Mon
    {
        public Mon()
        {
            KetQuas = new HashSet<KetQua>();
        }

        public string MaMh { get; set; }
        public string TenMh { get; set; }
        public int? SoTiet { get; set; }
        public string MaKhoa { get; set; }
        public bool? Status { get; set; }

        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
