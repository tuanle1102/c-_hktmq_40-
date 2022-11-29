﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proMidleTerm
{
    public class SinhVienDAO
    {
        private static SinhVienDAO instance;
        private static List<SinhVien> l;
        public static SinhVienDAO Instance
        {
            get { if (instance == null) instance = new SinhVienDAO(); return instance; }
            private set { instance = value; }
        }

        public List<SinhVien> LoadDS()
        {
            return l;
        }
        public SinhVienDAO()
        {
            l = new List<SinhVien>();
            docFile();
        }

        private void docFile()
        {
            using (StreamReader sr = new StreamReader("ListSV.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split('|');
                    if (s.Length == 4)
                    {
                        SinhVien i = new SinhVien(s[0], s[1], s[2], s[3]);
                        l.Add(i);
                    }
                }
            }
        }

        private void luuFile()
        {
            using (StreamWriter sw = new StreamWriter("ListSV.txt"))
            {
                for (int i = 0; i <l.Count; i++)
                {
                    sw.WriteLine(l[i].getDinhDangLuuFile());
                }
            }
        }
        public SinhVien getByTaiKhoan(string tk)
        {
            foreach (SinhVien i in l)
                if (i.Masv == tk)
                    return i;
            return null;
        }
            public SinhVien getByMa(string masv)
        {
            foreach (SinhVien i in l)
                if (i.Masv == masv)
                    return i;
            return null;
        }


        private string getMa()
        {
            if (l.Count == 0) return "SV001";
            string ma = l[l.Count - 1].Masv;
            string tam = "";
            for (int i = 3; i < ma.Length; i++)
                tam += ma[i];
            int so = int.Parse(tam);
            so++;
            string s = so + "";
            ma = "SV";
            for (int i = 0; i < 3 - s.Length; i++)
                ma += "0";
            ma += s;
            return ma;
        }
        public void them(string hotensv, string lop, string khoa)
        {   
            l.Add(new SinhVien(getMa(),hotensv,lop,khoa));
            luuFile();
        }
        public void xoa(string masv)
        {
            int i;
            for (i = 0; i < l.Count; i++)
                if (l[i].Masv == masv)
                    break;
            if (i < l.Count)
                l.RemoveAt(i);
            luuFile();
        }
        public void capNhat(string masv, string hotensv, string lop, string khoa)
        {
            SinhVien u = getByMa(masv);
            SinhVien u1 = new SinhVien(masv,hotensv,lop,khoa);
            int i;
            for (i = 0; i < l.Count; i++)
                if (l[i].Masv == masv)
                    l[i] = u1;
            luuFile();
        }


    }
}
