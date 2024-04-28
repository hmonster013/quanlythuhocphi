using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class CTCHUYENNGANH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MACTCN { get; set; }
        [ForeignKey("CHUYENNGANH")]
        public string? MACN { get; set; }
        public CHUYENNGANH? CHUYENNGANH { get; set; }
        [ForeignKey("MONHOC")]
        public string? MAMH { get; set; }
        public MONHOC? MONHOC { get; set; }
    }
}
