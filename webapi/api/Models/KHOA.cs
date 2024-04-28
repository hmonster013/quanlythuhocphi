using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class KHOA
    {
        [Key]
        public string MAKHOA { get; set; }
        public string TENKHOA { get; set; }
        public double DONGIA { get; set; }
        public List<CHUYENNGANH> CHUYENNGANHs { get; set; } = new List<CHUYENNGANH>();
        // public List<GIANGVIEN> GIANGVIENs { get; set; } = new List<GIANGVIEN>();
    }
}
