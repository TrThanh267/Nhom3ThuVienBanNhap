using System;
using System.Collections.Generic;

namespace Nhom3ThuVienBanNhap.Models;

public partial class LoaiCong
{
    public int MaLoaiCong { get; set; }

    public string? TenloaiCong { get; set; }

    public virtual ICollection<ChamCong> ChamCongs { get; set; } = new List<ChamCong>();
}
