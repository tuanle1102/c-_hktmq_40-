using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proMidleTerm
{
    public class NguoiDung
    {
        private string ma;
        private string ten;
        private string taiKhoan;
        private string matKhau;
        private string loai;
        
        public NguoiDung()
        {

        }
        public NguoiDung(string ma, string ten, string taiKhoan, string matKhau, string loai)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.TaiKhoan = taiKhoan;
            this.MatKhau = matKhau;
            this.Loai = loai;
        }

        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Loai { get => loai; set => loai = value; }
        public string getDinhDangLuuFile()
        {
            return ma + "|" + ten + "|" + taiKhoan + "|" + matKhau + "|" + loai;
        }
    }
}
