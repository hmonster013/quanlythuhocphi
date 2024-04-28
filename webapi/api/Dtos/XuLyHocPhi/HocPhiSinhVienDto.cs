using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.XuLyHocPhi
{
    public class HocPhiSinhVienDto
    {
        public int MAPT { get; set; }
        public string MASV { get; set; }
        public int MADK { get; set; }
        public string NIENKHOA { get; set; }
        public int HOCKY { get; set; }
        public double HOCPHI { get; set; }
        public double DADONG { get; set; }
        public double CHUADONG { get; set; }
    }
}