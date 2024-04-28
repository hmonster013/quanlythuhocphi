using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class CTDANGKY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MACTDK { get; set; }
        [ForeignKey("LOPHOCPHAN")]
        public int? MALHP { get; set; }
        // public LOPHOCPHAN? LOPHOCPHAN { get; set; }
        [ForeignKey("DANGKY")]
        public int? MADK { get; set; }
        // public DANGKY? DANGKY { get; set; }
    }
}
