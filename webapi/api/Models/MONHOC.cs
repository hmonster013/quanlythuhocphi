using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class MONHOC
    {
        [Key]
        public string MAMH { get; set; }
        public string TENMH { get; set; }
        public int HOCKY { get; set; }
        public int SOTINCHI { get; set; }
        // public List<LOPHOCPHAN> LOPHOCPHANs { get; set; } = new List<LOPHOCPHAN>();
        // public List<CTCHUYENNGANH> CTCHUYENNGANHs { get; set; } = new List<CTCHUYENNGANH>();
    }
}
