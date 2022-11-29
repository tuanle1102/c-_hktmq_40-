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
 
        public Frm_Main()
        {
            InitializeComponent();
            load();
            

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
           
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Frm_Home();

        }

        private void pnHeThong_Paint(object sender, PaintEventArgs e)
        {
            Frm_Home();
        }
       

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
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
        private void Frm_Home() => OpenChildForm(new Frm_Home());

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.DarkTurquoise)
            {
                    button1.BackColor = Color.Green;
                    quanLyNguoiDung();
            }
               
            else button1.BackColor = Color.DarkTurquoise;
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void Frm_QLSV() => OpenChildForm(new Frm_QuanLySinhVien());
        private void button3_Click(object sender, EventArgs e)
        {
            Frm_QLSV();
           
        }
    }
}
