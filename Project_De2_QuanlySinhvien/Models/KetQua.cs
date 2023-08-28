using System;
using System.Collections.Generic;

#nullable disable

namespace Project_De2_QuanlySinhvien.Models
{
    public partial class KetQua
    {
        public string MaSo { get; set; }
        public string MaMh { get; set; }
        public decimal? Diem { get; set; }
        public bool? Status { get; set; }

        public virtual Mon MaMhNavigation { get; set; }
        public virtual SinhVien MaSoNavigation { get; set; }
    }
}
