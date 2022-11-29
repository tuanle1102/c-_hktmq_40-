using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace proMidleTerm
{
    public class NguoiDungDAO
    {
        private static NguoiDungDAO instance;
        private static List<NguoiDung> l;
        public static NguoiDungDAO Instance
        {
            get { if (instance == null) instance = new NguoiDungDAO(); return instance; }
            private set { instance = value; }
        }

        public List<NguoiDung> loadDS()
        {
            return l;
        }   
        public NguoiDungDAO() {
            l = new List<NguoiDung>();
            docFile();
        }
        private void docFile()
        {
            using (StreamReader sr = new StreamReader("User.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split('|');
                    if (s.Length == 5)
                    {
                        NguoiDung i = new NguoiDung(s[0], s[1], s[2], s[3], s[4]);
                        l.Add(i);
                    }
                }
            }
        }
        private void luuFile()
        {
            using (StreamWriter sw = new StreamWriter("User.txt"))
            {
                for (int i = 0; i < l.Count; i++)
                {
                    sw.WriteLine(l[i].getDinhDangLuuFile());
                }
            }
        }
        public NguoiDung getByMa(string ma)
        {
            foreach (NguoiDung i in l)
                if (i.Ma == ma)
                    return i;
            return null;
        }
        public NguoiDung getByTaiKhoan(string tk)
        {
            foreach (NguoiDung i in l)
                if (i.TaiKhoan == tk)
                    return i;
            return null;
        }
        public bool checkDangNhap(string tk,string mk)
        {
            foreach (NguoiDung i in l)
                if (i.TaiKhoan == tk&&i.MatKhau==mk)
                    return true;
            return false;
        }
        private string getMa()
        {
            if (l.Count == 0) return "USER0001";
            string ma = l[l.Count - 1].Ma;
            string tam = "";
            for (int i = 4; i < ma.Length; i++)
                tam += ma[i];
            int so = int.Parse(tam);
            so++;
            string s = so + "";
            ma = "USER";
            for (int i = 0; i < 4 - s.Length; i++)
                ma += "0";
            ma += s;
            return ma;

        }
        public void them(string ten, string taiKhoan, string matKhau, string loai)
        {
            l.Add(new NguoiDung(getMa(), ten, taiKhoan, matKhau, loai));
            luuFile();
        }
        public void xoa(string ma)
        {
            int i;
            for (i = 0; i < l.Count; i++)
                if (l[i].Ma == ma)
                    break;
            if (i < l.Count)
                l.RemoveAt(i);
            luuFile();
        }
        public void capNhat(string ma, string ten, string taiKhoan)
        {
            NguoiDung u = getByMa(ma);
            NguoiDung u1 = new NguoiDung(ma, ten, taiKhoan, u.MatKhau, u.Loai);
            int i;
            for (i = 0; i < l.Count; i++)
                if (l[i].Ma == ma)
                    l[i] = u1;
            luuFile();
        }
    }
}
