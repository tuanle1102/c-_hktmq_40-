using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proMidleTerm
{
    public partial class Frm_QuanLySinhVien : Form
    {
        public Frm_QuanLySinhVien()
        {
            InitializeComponent();
            loadDS();
        }

        private void loadDS() {
            dgvSinhVien.Rows.Clear();
            int stt = 0;
            foreach (SinhVien i in SinhVienDAO.Instance.LoadDS())
            {
                DataGridViewRow row = (DataGridViewRow)dgvSinhVien.Rows[0].Clone();
                stt++;
                row.Cells[0].Value = stt + "";
                row.Cells[1].Value = i.Masv;
                row.Cells[2].Value = i.Hotensv;
                row.Cells[3].Value = i.Lop;
                row.Cells[4].Value = i.Khoa;

                dgvSinhVien.Rows.Add(row);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {   

            if (string.IsNullOrEmpty(tbTenSV.Text))
            {
                lbLoi.Text = "Tên người dùng không được để trống !";
                return;
            }
            if (string.IsNullOrEmpty(tbLop.Text))
            {
                lbLoi.Text = "Lop không được để trống !";
                return;
            }
            if (SinhVienDAO.Instance.getByTaiKhoan(tbMaSV.Text) != null)
            {
                lbLoi.Text = "Ma Sinh Vien Da Duoc Su Dung ";
                return;
            }
          
            SinhVienDAO.Instance.them(tbTenSV.Text,tbLop.Text,tbKhoa.Text);
            loadDS();
            lbLoi.Text = "Thêm người dùng thành công";
        }

        private void pnBD_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvSinhVien.Rows[e.RowIndex];
                tbMaSV.Text = Convert.ToString(row.Cells[1].Value);
                tbTenSV.Text = Convert.ToString(row.Cells[2].Value);
                tbLop.Text = Convert.ToString(row.Cells[3].Value);
                tbKhoa.Text = Convert.ToString(row.Cells[4].Value);
            
            }
            catch (Exception)
            { 

            }
        }

        private void lbLoi_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            loadDS();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SinhVien u = SinhVienDAO.Instance.getByMa(tbMaSV.Text);
            if (u == null)
            {
                lbLoi.Text = "Hãy chọn sinh viên cần sửa trước !";
                return;
            }
            if (string.IsNullOrEmpty(tbTenSV.Text))
            {
                lbLoi.Text = "Họ tên không được để trống !";
                return;
            }
            if (string.IsNullOrEmpty(tbLop.Text))
            {
                lbLoi.Text = "Lớp không được để trống !";
                return;
            }
            SinhVien u1 = SinhVienDAO.Instance.getByMa(tbMaSV.Text);

            if (u1 != null && u1.Masv != u.Masv)
            {
                lbLoi.Text = "Mã Sinh Viên đã được sử dụng !";
                return;
            }
            SinhVienDAO.Instance.capNhat(u.Masv, tbTenSV.Text, tbLop.Text,tbKhoa.Text);
            loadDS();
            lbLoi.Text = "Cập nhật sinh viên thành công";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SinhVien u = SinhVienDAO.Instance.getByMa(tbMaSV.Text);
            if (u == null)
            {
                lbLoi.Text = "Hãy chọn sinh viên cần xóa trước !";
                return;
            }

            if (MessageBox.Show("Xác nhận xóa sinh viên:" + u.Hotensv + " ?", "Xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                SinhVienDAO.Instance.xoa(u.Masv);
                loadDS();
                lbLoi.Text = "Xóa sinh viên thành công";
            }
        }
    }
}
