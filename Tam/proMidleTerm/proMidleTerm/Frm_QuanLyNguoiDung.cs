using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace proMidleTerm
{
    public partial class Frm_QuanLyNguoiDung : Form
    {
        public Frm_QuanLyNguoiDung()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            dgvSinhVien.Rows.Clear();
            int stt = 0;
            foreach (NguoiDung i in NguoiDungDAO.Instance.loadDS())
            {
                DataGridViewRow row = (DataGridViewRow)dgvSinhVien.Rows[0].Clone();
                stt++;
                row.Cells[0].Value = stt + "";
                row.Cells[1].Value = i.Ma;
                row.Cells[2].Value = i.Ten;
                row.Cells[3].Value = i.TaiKhoan;
                row.Cells[4].Value = i.Loai;
                dgvSinhVien.Rows.Add(row);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDS();
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = new DataGridViewRow();
                row = dgvSinhVien.Rows[e.RowIndex];
                tbMa.Text = Convert.ToString(row.Cells[1].Value);
                if (string.IsNullOrEmpty(tbMa.Text))
                {
                    return;
                }
                tbTen.Text = Convert.ToString(row.Cells[2].Value);
                tbTaiKhoan.Text = Convert.ToString(row.Cells[3].Value);
                NguoiDung u = NguoiDungDAO.Instance.getByMa(tbMa.Text);
                tbMatKhau.Text = u.MatKhau;
                tbLoaiUser.Text = Convert.ToString(row.Cells[4].Value);
            }
            catch (Exception)
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbTen.Text))
            {
                lbLoi.Text = "Tên người dùng không được để trống !";
                return;
            }
            if (string.IsNullOrEmpty(tbTaiKhoan.Text))
            {
                lbLoi.Text = "Tài khoản đăng nhập không được để trống !";
                return;
            }
            if (NguoiDungDAO.Instance.getByTaiKhoan(tbTaiKhoan.Text)!=null)
            {
                lbLoi.Text = "Tài khoản đăng nhập đã được sử dụng !";
                return;
            }
            NguoiDungDAO.Instance.them(tbTen.Text, tbTaiKhoan.Text, "12345", "User");
            loadDS();
            lbLoi.Text = "Thêm người dùng thành công";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NguoiDung u = NguoiDungDAO.Instance.getByMa(tbMa.Text);
            if (u==null)
            {
                lbLoi.Text = "Hãy chọn người dùng cần sửa trước !";
                return;
            }
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                lbLoi.Text = "Tên người dùng không được để trống !";
                return;
            }
            if (string.IsNullOrEmpty(tbTaiKhoan.Text))
            {
                lbLoi.Text = "Tài khoản đăng nhập không được để trống !";
                return;
            }
            NguoiDung u1 = NguoiDungDAO.Instance.getByTaiKhoan(tbTaiKhoan.Text);

            if (u1!=null&&u1.Ma!=u.Ma)
            {
                lbLoi.Text = "Tài khoản đăng nhập đã được sử dụng !";
                return;
            }
            NguoiDungDAO.Instance.capNhat(u.Ma, tbTen.Text,tbTaiKhoan.Text);
            loadDS();
            lbLoi.Text = "Cập nhật thông tin người dùng thành công";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NguoiDung u=NguoiDungDAO.Instance.getByMa(tbMa.Text);
            if (u == null)
            {
                lbLoi.Text = "Hãy chọn người dùng cần xóa trước !";
                return;
            }
            if (u.Loai == "Admin")
            {
                lbLoi.Text = "Không thể xóa quản trị viên ! !";
                return;
            }

            if (MessageBox.Show("Xác nhận xóa người dùng:"+u.Ten+" ?", "Xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                NguoiDungDAO.Instance.xoa(u.Ma);
                loadDS();
                lbLoi.Text = "Xóa người dùng thành công";
            }

        }

        private void Frm_QuanLyNguoiDung_Load(object sender, EventArgs e)
        {

        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnBD_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
