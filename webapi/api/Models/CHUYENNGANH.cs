using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class CHUYENNGANH
    {
        [Key]
        public string MACN { get; set; }
        public string TENCN { get; set; }
        [ForeignKey("KHOA")]
        public string? MAKHOA { get; set; }
        public KHOA? KHOA { get; set; }
        public List<CTCHUYENNGANH> CTCHUYENNGANHs { get; set; }
        // public List<LOPHOCPHAN> LOPHOCPHANs { get; set; } = new List<LOPHOCPHAN>();
        public List<LOP> LOPs { get; set; }
    }   
}
