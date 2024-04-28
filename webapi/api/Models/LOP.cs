using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class LOP
    {
        [Key]
        public string MALOP { get; set; }
        [ForeignKey("CHUYENNGANH")]
        public string? MACN { get; set; }
        public CHUYENNGANH? CHUYENNGANH { get; set; }
        public List<SINHVIEN> SINHVIENs { get; set; }
    }
}
