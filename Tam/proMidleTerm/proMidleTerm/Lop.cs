using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proMidleTerm
{
    public class Lop
    {
        private string malop;
        private string tenlop;
        private string siso;
        private string khoa;

        public Lop()
        {
        }

        public Lop(string malop, string tenlop, string siso, string khoa)
        {
            this.Malop = malop;
            this.Tenlop = tenlop;
            this.Siso = siso;
            this.Khoa = khoa;
        }

        public string Malop { get => malop; set => malop = value; }
        public string Tenlop { get => tenlop; set => tenlop = value; }
        public string Siso { get => siso; set => siso = value; }
        public string Khoa { get => khoa; set => khoa = value; }

        public string getDinhDangLuuFile()
        {
            return malop + "|" + tenlop + "|" + siso + "|" + khoa;
        }
    }
}
