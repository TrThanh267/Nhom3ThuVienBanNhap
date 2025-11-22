using System;
using System.Collections.Generic;

namespace Nhom3ThuVienBanNhap.Models;

public partial class CaLam
{
    public int MaCaLam { get; set; }

    public string? TenCaLam { get; set; }

    public virtual ICollection<ChamCong> ChamCongs { get; set; } = new List<ChamCong>();
}
