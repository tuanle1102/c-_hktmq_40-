using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proMidleTerm
{
    public class SinhVien
    {
        private string masv;
        private string hotensv;
        private string lop;
        private string khoa;

        public SinhVien()
        {
        }


        public SinhVien(string masv, string hotensv, string lop, string khoa)
        {
            this.Masv = masv;
            this.Hotensv = hotensv;
            this.Lop = lop;
            this.Khoa = khoa;
     
        }

        public string Masv { get => masv; set => masv = value; }
        public string Hotensv { get => hotensv; set => hotensv = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Khoa { get => khoa; set => khoa = value; }


        public string getDinhDangLuuFile()
        {
            return masv + "|" + hotensv + "|" + lop + "|" + khoa;
        }
    }
}
