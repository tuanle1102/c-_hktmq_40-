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
    public partial class Frm_QuanLyLop : Form
    {
        public Frm_QuanLyLop()
        {
            InitializeComponent();
            loadDS();
        }

        private void loadDS()
        {
            dgvLOP.Rows.Clear();
            int stt = 0;
            foreach (Lop i in LopDao.Instance.LoadDS())
            {
                DataGridViewRow row = (DataGridViewRow)dgvLOP.Rows[0].Clone();
                stt++;
                row.Cells[0].Value = stt + "";
                row.Cells[1].Value = i.Malop;
                row.Cells[2].Value = i.Tenlop;
                row.Cells[3].Value = i.Siso;
                row.Cells[4].Value = i.Khoa;

                dgvLOP.Rows.Add(row);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_QuanLyLop_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTenLop.Text))
            {
                lbLoi.Text = "Tên lớp không được để trống !";
                return;
            }
            if (string.IsNullOrEmpty(tbSiSo.Text))
            {
                lbLoi.Text = "Sỉ số không được để trống !";
                return;
            }
            if (string.IsNullOrEmpty(tbKhoa.Text))
            {
                lbLoi.Text = "Khoa không được để trống !";
                return;
            }
            if (LopDao.Instance.getByTaiKhoan(tbMaLop.Text) != null)
            {
                lbLoi.Text = "Ma Sinh Vien Da Duoc Su Dung ";
                return;
            }

            LopDao.Instance.them(tbTenLop.Text, tbSiSo.Text, tbKhoa.Text);
            loadDS();
            lbLoi.Text = "Thêm lớp thành công";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            loadDS();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Lop u = LopDao.Instance.getByMa(tbMaLop.Text);
            if (u == null)
            {
                lbLoi.Text = "Hãy chọn lớp cần sửa trước !";
                return;
            }
            if (string.IsNullOrEmpty(tbTenLop.Text))
            {
                lbLoi.Text = "Tên lớp không được để trống !";
                return;
            }
            if (string.IsNullOrEmpty(tbSiSo.Text))
            {
                lbLoi.Text = "Sỉ số không được để trống !";
                return;
            }
            Lop u1 = LopDao.Instance.getByMa(tbMaLop.Text);

            if (u1 != null && u1.Malop != u.Malop)
            {
                lbLoi.Text = "Mã lớp đã được sử dụng !";
                return;
            }
            LopDao.Instance.capNhat(u.Malop, tbTenLop.Text, tbSiSo.Text, tbKhoa.Text);
            loadDS();
            lbLoi.Text = "Cập nhật lớp thành công";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Lop u = LopDao.Instance.getByMa(tbMaLop.Text);
            if (u == null)
            {
                lbLoi.Text = "Hãy chọn lớp cần xóa trước !";
                return;
            }

            if (MessageBox.Show("Xác nhận xóa lớp:" + u.Tenlop + " ?", "Xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                LopDao.Instance.xoa(u.Malop);
                loadDS();
                lbLoi.Text = "Xóa lớp thành công";
            }
        }

        private void dgvLOP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvLOP.Rows[e.RowIndex];
                tbMaLop.Text = Convert.ToString(row.Cells[1].Value);
                tbTenLop.Text = Convert.ToString(row.Cells[2].Value);
                tbSiSo.Text = Convert.ToString(row.Cells[3].Value);
                tbKhoa.Text = Convert.ToString(row.Cells[4].Value);

            }
            catch (Exception)
            {

            }
        }
    }
}
