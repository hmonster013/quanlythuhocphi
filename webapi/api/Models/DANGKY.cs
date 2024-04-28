using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class DANGKY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MADK { get; set; }
        public int HOCKY { get; set; }
        [ForeignKey("SINHVIEN")]
        public string? MASV { get; set; }
        // public SINHVIEN? SINHVIEN { get; set; }
        // public List<CTDANGKY> CTDANGKYs { get; set; } = new List<CTDANGKY>();
    }
}

