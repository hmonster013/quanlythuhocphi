using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class LOPHOCPHAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MALHP { get; set; }
        public string NIENKHOA { get; set; }
        public int HOCKY { get; set; } = 1;
        [ForeignKey("MONHOC")]
        public string? MAMH { get; set; }
        // public MONHOC? MONHOC { get; set; }
        [ForeignKey("GIANGVIEN")]
        public string? MAGV { get; set; }
        // public GIANGVIEN? GIANGVIEN { get; set; }
        [ForeignKey("CHUYENNGANH")]
        public string? MACN { get; set; }
        // public CHUYENNGANH? CHUYENNGANH { get; set; }
        public bool HUYLOP { get; set; }
        // public List<CTDANGKY> CTDANGKYs { get; set; } = new List<CTDANGKY>();
    }
}

