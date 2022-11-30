using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proMidleTerm
{
    public class LopDao
    {
        private static LopDao instance;
        private static List<Lop> l;
        public static LopDao Instance
        {
            get { if (instance == null) instance = new LopDao(); return instance; }
            private set { instance = value; }
        }

        public List<Lop> LoadDS()
        {
            return l;
        }
        public LopDao()
        {
            l = new List<Lop>();
            docFile();
        }

        private void docFile()
        {
            using (StreamReader sr = new StreamReader("ListLop.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split('|');
                    if (s.Length == 5)
                    {
                        Lop i = new Lop(s[0], s[1], s[2], s[3]);
                        l.Add(i);
                    }
                }
            }
        }

        private void luuFile()
        {
            using (StreamWriter sw = new StreamWriter("ListLop.txt"))
            {
                for (int i = 0; i < l.Count; i++)
                {
                    sw.WriteLine(l[i].getDinhDangLuuFile());
                }
            }
        }

        public Lop getByTaiKhoan(string tk)
        {
            foreach (Lop i in l)
                if (i.Malop == tk)
                    return i;
            return null;
        }
        public Lop getByMa(string masv)
        {
            foreach (Lop i in l)
                if (i.Malop == masv)
                    return i;
            return null;
        }


        private string getMa()
        {
            if (l.Count == 0) return "CT111";
            string ma = l[l.Count - 1].Malop;
            string tam = "";
            for (int i = 3; i < ma.Length; i++)
                tam += ma[i];
            int so = int.Parse(tam);
            so++;
            string s = so + "";
            ma = "CT";
            for (int i = 0; i < 3 - s.Length; i++)
                ma += "0";
            ma += s;
            return ma;
        }

        public void them(string tenlop, string lop, string khoa)
        {
            l.Add(new Lop(getMa(), tenlop, lop, khoa));
            luuFile();
        }

        public void xoa(string malop)
        {
            int i;
            for (i = 0; i < l.Count; i++)
                if (l[i].Malop == malop)
                    break;
            if (i < l.Count)
                l.RemoveAt(i);
            luuFile();
        }

        public void capNhat(string malop, string tenlop, string siso, string khoa)
        {
            Lop u = getByMa(malop);
            Lop u1 = new Lop(malop, tenlop, siso, khoa);
            int i;
            for (i = 0; i < l.Count; i++)
                if (l[i].Malop == malop)
                    l[i] = u1;
            luuFile();
        }
    }
}
