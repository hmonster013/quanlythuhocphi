using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class NGUOIDUNG
    {
        [Key]
        public string TENTAIKHOAN { get; set; }
        public string MATKHAU { get; set; }
        public string QUYEN { get; set; }
        // public SINHVIEN SINHVIEN { get; set; }
    }
}
