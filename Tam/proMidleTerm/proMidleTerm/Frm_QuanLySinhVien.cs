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

        private void tbMaSV_TextChanged(object sender, EventArgs e)
        {

        }


        public void ExportFile(DataTable dataTable, string sheetName, string title) { 
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            oExcel.Visible= true;
            oExcel.DisplayAlerts= false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
                
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold= true;
            head.Font.Name = "Times New Roman";
            head.Font.Size= "20";
            head.Interior.ColorIndex = 3;    
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            

            Microsoft.Office.Interop.Excel.Range rowhead = oSheet.get_Range("A2", "E2");
            rowhead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            rowhead.Interior.ColorIndex = 6;


            //tao tieu de cot
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3","A3");
            cl1.Value = "STT";
            cl1.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value = "Ma sv";
            cl2.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value = "Ho ten";
            cl3.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value = "Lop";
            cl4.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value = "Khoa";
            cl5.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range titlerow = oSheet.get_Range("A3", "E3");
            titlerow.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            titlerow.Interior.ColorIndex = 4;
            

            //tao mang theo datatabel

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];
            // chuyen du lieu tu  datatable vao doi tuong

            for (int rows = 0; rows < dataTable.Rows.Count; rows++) { 
                DataRow dataRow = dataTable.Rows[rows];

                for (int col = 0; col <dataTable.Columns.Count;col++)
                {
                    arr[rows,col] = dataRow[col];

                }
            }

            // thiet lap dien du lieu

            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count -2;
            int ColumnEnd = dataTable.Columns.Count;


            // o bat dau
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, ColumnEnd];

            // lay ve vung dien du lieu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1,c2);

            range.Value2 = arr;

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;


            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;




        }



        private void button11_Click(object sender, EventArgs e)
        {
            DataTable dataTable= new DataTable();   

            DataColumn col1 = new DataColumn("STT");
            DataColumn col2 = new DataColumn("MaSV");
            DataColumn col3 = new DataColumn("HoTen");
            DataColumn col4 = new DataColumn("Lop");
            DataColumn col5 = new DataColumn("Khoa");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);

            foreach (DataGridViewRow dtgRows in dgvSinhVien.Rows) {
                DataRow dtrow = dataTable.NewRow();

                dtrow[0] = dtgRows.Cells[0].Value;
                dtrow[1] = dtgRows.Cells[1].Value;
                dtrow[2] = dtgRows.Cells[2].Value;
                dtrow[3] = dtgRows.Cells[3].Value;
                dtrow[4] = dtgRows.Cells[4].Value;
                
            
                dataTable.Rows.Add(dtrow);

            }

            ExportFile(dataTable, "DANH SÁCH", " DANH SÁCH SINH VIÊN");



        }
    }
}
