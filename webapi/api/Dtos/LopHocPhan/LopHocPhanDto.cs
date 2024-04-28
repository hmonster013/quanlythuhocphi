using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.LopHocPhan
{
    public class LopHocPhanDto
    {
        public int MALHP { get; set; }
        public string NIENKHOA { get; set; }
        public int HOCKY { get; set; }
        public string? MAMH { get; set; }
        public string? MAGV { get; set; }
        public string? MACN { get; set; }
        public bool HUYLOP { get; set; }        
    }
}