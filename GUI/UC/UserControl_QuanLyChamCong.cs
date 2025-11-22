using Nhom3ThuVienBanNhap.BLL;
using Nhom3ThuVienBanNhap.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienNhom3.GUI.UC
{
    public partial class UserControl_QuanLyChamCong : UserControl
    {
        private readonly QuanLyChamCong_BLL _BLL;
        public UserControl_QuanLyChamCong()
        {
            InitializeComponent();
            _BLL = new QuanLyChamCong_BLL();
            LoadData();
        }
        public void LoadData()
        {
            DataGridView_DachSachChamCong.DataSource = _BLL.GetListChamCong();

            loadComboBoxNhanVien();
            LoadComboBoxLoaiCong();
            LoadComBoxCaLam();
        }
        public void loadComboBoxNhanVien()
        {
            ComboBox_NhanVien.DataSource = _BLL.GetNhanViens();
            ComboBox_NhanVien.DisplayMember = "TenNhanVien";
            ComboBox_NhanVien.ValueMember = "MaNhanVien";
            ComboBox_NhanVien.SelectedValue = 2;
        }
        public void LoadComBoxCaLam()
        {
            ComboBox_CaLam.DataSource =_BLL.GetCaLams();
            ComboBox_CaLam.DisplayMember = "TenCaLam";
            ComboBox_CaLam.ValueMember = "MaCaLam";
        }
        public void LoadComboBoxLoaiCong()
        {
            ComboBox_LoaiCong.DataSource=_BLL.GetLoaiCong();
            ComboBox_LoaiCong.DisplayMember = "TenLoaiCong";
            ComboBox_LoaiCong.ValueMember = "MaLoaiCong";
        }

        private void dateTimePicker_TinhLuongThang_ValueChanged(object sender, EventArgs e)
        {
            int thang = dateTimePicker_TinhLuongThang.Value.Month;
            int nam = dateTimePicker_TinhLuongThang.Value.Year;
        }
        public void ThongTinNhanVien(NhanVien nhanVien)
        {
            if (nhanVien != null)
            {
                TextBox_MaNhanVien.Text = nhanVien.MaNhanVien.ToString();
                TextBox_TenNhanVien.Text = nhanVien.TenNhanVien;
                if (nhanVien.NgaySinh.HasValue)
                {
                    DateTimePicker_Ngáyinh.Value = nhanVien.NgaySinh.Value.ToDateTime(TimeOnly.MinValue);
                }
                else
                {
                    DateTimePicker_Ngáyinh.Value = DateTime.Now;
                }

                TextBox_GioiTinh.Text = nhanVien.GioiTinh;
                TextBox_DiaChi.Text = nhanVien.DiaChi;
                TextBox_SoDienThoai.Text = nhanVien.SoDienThoai;
                TextBox_Email.Text = nhanVien.Email;
                if (nhanVien.TrangThai == "Đang làm việc")
                {
                    radioButton_HoatDong.Checked = true;
                }
                else
                {
                    radioButton_DaNghi.Checked = true;
                }
                TextBox_TaiKhoan.Text = nhanVien.MaTaiKhoanNavigation != null
                                        ? nhanVien.MaTaiKhoanNavigation.TenTaiKhoan
                                        : "Không có tài khoản";

            }

        }

        private void Button_ChamCongVao_Click(object sender, EventArgs e)
        {
            if (ComboBox_NhanVien.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để chấm công");
                return;
            }
            if (ComboBox_CaLam.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn ca làm để chấm công");
                return;
            }
            if (ComboBox_LoaiCong.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn loại công để chấm công");
                return;
            }


        }

        private void ComboBox_NhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhanVien nhanVien = ComboBox_NhanVien.SelectedItem as NhanVien;
            if(!int.TryParse(ComboBox_NhanVien.SelectedValue.ToString(), out int idnv))
            {
                return;
            }
            NhanVien IDNv = _BLL.GetNhanViens().FirstOrDefault(x=>x.MaNhanVien == idnv);
            if (IDNv != null)
            {
                ThongTinNhanVien(IDNv);
            }
        }
    }
}
