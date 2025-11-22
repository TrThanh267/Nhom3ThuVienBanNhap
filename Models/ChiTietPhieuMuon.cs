using System;
using System.Collections.Generic;

namespace Nhom3ThuVienBanNhap.Models;

public partial class ChiTietPhieuMuon
{
    public int MaChiTietPhieuMuon { get; set; }

    public int? SoLuongMuon { get; set; }

    public string? TinhTrangSach { get; set; }

    public int? MaSach { get; set; }

    public int? MaPhieuMuon { get; set; }

    public virtual PhieuMuon? MaPhieuMuonNavigation { get; set; }

    public virtual Sach? MaSachNavigation { get; set; }
}
