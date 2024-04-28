using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class SINHVIEN
    {
        [Key]
        public string MASV { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        [ForeignKey("LOP")]
        public string MALOP { get; set; }
        public bool PHAI { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public bool DANGNGHIHOC { get; set; }   
        [ForeignKey("NGUOIDUNG")]
        public string TENTAIKHOAN { get; set; }
        public LOP? LOP { get; set; }
        // public List<PHIEUTHU> PHIEUTHUs { get; set; } = new List<PHIEUTHU>();
        // public List<DANGKY> DANGKYs { get; set; } = new List<DANGKY>();
    }
}

