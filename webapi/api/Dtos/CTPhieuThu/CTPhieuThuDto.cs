using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.CTPhieuThu
{
    public class CTPhieuThuDto
    {
        public int MACTPT { get; set; }
        public int? MAPT { get; set; }
        public DateTime NGAYDONG { get; set; }
        public double SOTIENDONG { get; set; }        
    }
}