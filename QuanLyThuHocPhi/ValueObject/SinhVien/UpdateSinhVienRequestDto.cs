using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValueObject.SinhVien
{
    public class UpdateSinhVienRequestDto
    {
        public string HO { get; set; }
        public string TEN { get; set; }
        public string MALOP { get; set; }
        public bool PHAI { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public bool DANGNGHIHOC { get; set; }   
        public string TENTAIKHOAN { get; set; }        
    }
}