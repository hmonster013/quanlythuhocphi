using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class CTPHIEUTHU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MACTPT { get; set; }
        [ForeignKey("PHIEUTHU")]
        public int? MAPT { get; set; }
        // public PHIEUTHU? PHIEUTHU { get; set; }
        public DateTime NGAYDONG { get; set; }
        public double SOTIENDONG { get; set; }
    }
}
