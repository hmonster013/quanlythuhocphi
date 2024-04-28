using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValueObject.CTPhieuThu
{
    public class UpdateCTPhieuThuRequestDto
    {
        public int MAPT { get; set; }
        public DateTime NGAYDONG { get; set; }
        public double SOTIENDONG { get; set; }        
    }
}