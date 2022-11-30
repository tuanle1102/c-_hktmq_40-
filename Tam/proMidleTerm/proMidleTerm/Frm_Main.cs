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
    public partial class Frm_Main : Form
    {
        private Form formCon;
        private int k;
 
        public Frm_Main()
        {
            InitializeComponent();
            load();
            k = 0;
            

        }
        private void OpenChildForm(Form childForm)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            formCon = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBD.Controls.Add(childForm);
            pnBD.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void load()
        {
            k = 0;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.BackColor == Color.DodgerBlue) {
                Frm_Home();
                pnHeThong.BackColor = Color.DeepSkyBlue;
                button2.BackColor = Color.DodgerBlue;
                button1.BackColor = Color.DodgerBlue;
               
            }
            
        }

        private void pnHeThong_Paint(object sender, PaintEventArgs e)
        {
            
        }
      
        
        private void label2_Click(object sender, EventArgs e)
        {   
          this.Close();
        }
        private void quanLyNguoiDung()
        {
            OpenChildForm(new Frm_QuanLyNguoiDung());
        }
        private void Frm_Home()
        {
            OpenChildForm(new Frm_Home());
        }
        private void button1_Click(object sender, EventArgs e)
        {     
           
        }

      

        private void Frm_QLSV()
        {
            OpenChildForm(new Frm_QuanLySinhVien());
        }
     

        private void pnBD_Paint(object sender, EventArgs e)
        {

        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            
        }
    

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(k<1)
            {
                k++;
                e.Cancel = true;
                return;

            }
            if (MessageBox.Show("Xác nhận thoát lần đăng nhập này ?", "Xác nhận", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void quanlyLop() {
            OpenChildForm(new Frm_QuanLyLop());
        }

     
        private void label7_Click(object sender, EventArgs e)
        {
            Frm_DangNhap fdn = new Frm_DangNhap();
            fdn.Show();
            this.Hide();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.DodgerBlue)
            {
                quanlyLop();
                button1.BackColor = Color.DeepSkyBlue;
                button2.BackColor = Color.DodgerBlue;
                button3.BackColor = Color.DodgerBlue;
                pnHeThong.BackColor = Color.DodgerBlue;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.DodgerBlue)
            {
                quanLyNguoiDung();
                button1.BackColor = Color.DodgerBlue;
                button2.BackColor = Color.DeepSkyBlue;
                button3.BackColor = Color.DodgerBlue;
                pnHeThong.BackColor = Color.DodgerBlue;

            }
      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(button3.BackColor == Color.DodgerBlue)
            {
                Frm_QLSV();
                button3.BackColor= Color.DeepSkyBlue;
                button2.BackColor= Color.DodgerBlue;
                button1.BackColor= Color.DodgerBlue;
                pnHeThong.BackColor = Color.DodgerBlue;

            }
            
        }

        private void pnHeThong_MouseClick(object sender, MouseEventArgs e)
        {
            Frm_Home();
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            panel6.BackColor = Color.DeepPink;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.DeepSkyBlue;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
