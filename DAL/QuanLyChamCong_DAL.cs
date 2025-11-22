using Microsoft.EntityFrameworkCore;
using Nhom3ThuVienBanNhap.DTO;
using Nhom3ThuVienBanNhap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom3ThuVienBanNhap.DAL
{
    internal class QuanLyChamCong_DAL
    {
        private readonly ThuVienNhom3Context _context = new ThuVienNhom3Context();
        public List<QuanLyChamCong_DTO> GetListChamCong()
        {
            var ListChamCong = _context.ChamCongs.Include(cc=>cc.MaLoaiCongNavigation)
                                                   .Include(cc=>cc.MaCaLamNavigation)
                                                   .Include(cc=>cc.MaNhanVienNavigation)
                                                    .ToList()
                                                    .Select((x,index)=> new QuanLyChamCong_DTO
                                                    {
                                                        STT = index + 1,
                                                        MaChamCong = x.MaChamCong,
                                                        NgayLam = x.NgayLam,
                                                        ThangLam = x.ThangLam,
                                                        NamLam = x.NamLam,
                                                        GioVao = x.GioVao,
                                                        PhutVao = x.PhutVao,
                                                        GioRa = x.GioRa,
                                                        PhutRa = x.PhutRa,
                                                        LoaiCong = x.MaLoaiCongNavigation.TenloaiCong,
                                                        CaLam = x.MaCaLamNavigation.TenCaLam,
                                                        NhanVien = x.MaNhanVienNavigation.TenNhanVien
                                                    }).ToList();
            return ListChamCong;
        }
        public bool ThemChamCong(ChamCong chamCong)
        {
            try
            {
                _context.ChamCongs.Add(chamCong);
                _context.SaveChanges();
                MessageBox.Show("Thêm chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm chấm công thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool KiemTraChamCongTonTai(int maNhanVien)
        {
            var today = DateTime.Today;
            return _context.ChamCongs.Any(cc=> cc.MaNhanVien == maNhanVien 
                                            && cc.NgayLam == today.Day 
                                            && cc.ThangLam == today.Month && cc.NamLam == today.Year);

        }
        public bool KiemTraChamCongVoiNhanVien(int IdNhanVien)
        {
            var nhanVien = _context.NhanViens
                            .FirstOrDefault(nv => nv.MaNhanVien == IdNhanVien);

            if (nhanVien == null)
            {
                MessageBox.Show("Nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return nhanVien.MaTaiKhoanNavigation.MaVaiTro == 2;

        }
        public NhanVien LayThongTinNhanVienQuaTaiKhoan(int maTaiKhoan)
        {
            var nhanVien = _context.NhanViens
                            .Include(nv => nv.MaTaiKhoanNavigation)
                            .FirstOrDefault(nv => nv.MaTaiKhoan == maTaiKhoan);


            if (nhanVien == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên cho tài khoản này!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return nhanVien;
        }
        public List<NhanVien> GetListNhanVien()
        {
            return _context.NhanViens.Include(x=>x.MaTaiKhoanNavigation)
                                    .Where(x=>x.MaTaiKhoanNavigation.MaVaiTro==2).ToList();
        }
        public List<CaLam> GetListCaLam()
        {
            return _context.CaLams.ToList();
        }
        public List<LoaiCong> GetListLoaiCong()
        {
            return _context.LoaiCongs.ToList();
        }


    }
}
