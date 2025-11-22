using Nhom3ThuVienBanNhap.DAL;
using Nhom3ThuVienBanNhap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom3ThuVienBanNhap.BLL
{
    internal class QuanLyDocGia_BLL
    {
        private QuanLyDocGia_DAL _quanLyDocGia_DAL = new QuanLyDocGia_DAL();
        public void KiemTraValidate(string SDT,string email)
        {
            if (_quanLyDocGia_DAL.KiemTraSoDienThoaiTonTai(SDT))
            {
                MessageBox.Show("Số điện thoại này đã được đăng kí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(_quanLyDocGia_DAL.KiemTraEmailTonTai(email))
            {
                MessageBox.Show("Email này đã được đăng kí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                return;
            }
        }
        public List<DTO.QuanLyDocGia_DTO> GetListDocGia()
        {
            return _quanLyDocGia_DAL.GetListDocGia();
        }
        public int ThemMaDoGia()
        {
            return _quanLyDocGia_DAL.ThemMaDoGia();
        }
        public bool ThemDocGia(DocGium docGia)
        {
            if (_quanLyDocGia_DAL.KiemTraSoDienThoaiTonTai(docGia.SoDienThoai))
            {
                MessageBox.Show("Số điện thoại này đã được đăng kí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_quanLyDocGia_DAL.KiemTraEmailTonTai(docGia.Email))
            {
                MessageBox.Show("Email này đã được đăng kí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                _quanLyDocGia_DAL.ThemDocGia(docGia);
                return true;
            }
        }
        public void SuaDocGia(DocGium docGia)
        {
            if( _quanLyDocGia_DAL.KiemTraSoDienThoaiTonTai(docGia.SoDienThoai))
            {
                MessageBox.Show("Số điện thoại này đã được đăng kí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (_quanLyDocGia_DAL.KiemTraEmailTonTai(docGia.Email))
            {
                MessageBox.Show("Email này đã được đăng kí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                _quanLyDocGia_DAL.SuaDocGia(docGia);
            }
        }
        public void XoaDocGia(int docgia)
        {
           if( _quanLyDocGia_DAL.KemTraDocGiaCoPhieuMuonChua(docgia))
            {
                MessageBox.Show("Độc giả này đang có phiếu mượn, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                _quanLyDocGia_DAL.XoaDocGia(docgia);
            }
        }
    }
}
