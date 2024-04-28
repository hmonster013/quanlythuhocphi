using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class GIANGVIEN
    {
        [Key]
        public string MAGV { get; set; }
        [ForeignKey("KHOA")]
        public string? MAKHOA { get; set; }
        // public KHOA? KHOA { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public string HOCHAM { get; set; }
        // public List<LOPHOCPHAN> LOPHOCPHANs { get; set; } = new List<LOPHOCPHAN>();
    }
}
