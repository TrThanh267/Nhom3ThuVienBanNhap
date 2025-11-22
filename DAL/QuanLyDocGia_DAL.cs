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
    internal class QuanLyDocGia_DAL
    {
        private readonly ThuVienNhom3Context _context = new ThuVienNhom3Context();
        public List<QuanLyDocGia_DTO> GetListDocGia()
        {
            return _context.DocGia.ToList()
                            .Select((x,index) => new QuanLyDocGia_DTO
                            {
                                STT = index + 1,
                                MaDocGia = x.MaDocGia,
                                TenDocGia = x.TenDocGia,
                                NgaySinh = x.NgaySinh,
                                GioiTinh = x.GioiTinh,
                                DiaChi = x.DiaChi,
                                SoDienThoai = x.SoDienThoai,
                                Email = x.Email,
                                TrangThai = x.TrangThai
                            }).ToList();
        }
        public int ThemMaDoGia()
        {
            return _context.DocGia.Any() ? _context.DocGia.Max(x => x.MaDocGia) + 1 : 1;
        }
        public bool KiemTraEmailTonTai(string email)
        {
            return _context.DocGia.Any(dg => dg.Email == email);
        }
        public bool KiemTraSoDienThoaiTonTai(string soDienThoai)
        {
            return _context.DocGia.Any(dg => dg.SoDienThoai == soDienThoai);
        }
        public bool KemTraDocGiaCoPhieuMuonChua(int maDocGia)
        {
            return _context.PhieuMuons.Any(pm => pm.MaDocGia == maDocGia);
        }
        
        public bool ThemDocGia(DocGium docGia)
        {
            try
            {
                _context.DocGia.Add(docGia);
                _context.SaveChanges();
                MessageBox.Show("Thêm độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm độc giả thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void SuaDocGia(DocGium docGia)
        {
            try
            {
                var existingDocGia = _context.DocGia.FirstOrDefault(dg=>dg.MaDocGia==docGia.MaDocGia);
                if (existingDocGia != null)
                {
                    existingDocGia.TenDocGia = docGia.TenDocGia==null ? existingDocGia.TenDocGia : docGia.TenDocGia;
                    existingDocGia.NgaySinh = docGia.NgaySinh == null ? existingDocGia.NgaySinh : docGia.NgaySinh;
                    existingDocGia.GioiTinh = docGia.GioiTinh == null ? existingDocGia.GioiTinh : docGia.GioiTinh;
                    existingDocGia.HinhAnh = docGia.HinhAnh == null ? existingDocGia.HinhAnh : docGia.HinhAnh;
                    existingDocGia.DiaChi = docGia.DiaChi == null ? existingDocGia.DiaChi : docGia.DiaChi;
                    existingDocGia.SoDienThoai = docGia.SoDienThoai == null ? existingDocGia.SoDienThoai : docGia.SoDienThoai;
                    existingDocGia.Email = docGia.Email == null ? existingDocGia.Email : docGia.Email;
                    existingDocGia.TrangThai = docGia.TrangThai == null ? existingDocGia.TrangThai : docGia.TrangThai;
                    _context.DocGia.Update(existingDocGia);
                    _context.SaveChanges();
                    MessageBox.Show("Sửa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Độc giả không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa độc giả thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void XoaDocGia(int maDocGia)
        {
            try
            {
                var existingDocGia = _context.DocGia.FirstOrDefault(dg => dg.MaDocGia == maDocGia);
                if (existingDocGia != null)
                {
                    _context.DocGia.Remove(existingDocGia);
                    _context.SaveChanges();
                    MessageBox.Show("Xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Độc giả không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa độc giả thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
