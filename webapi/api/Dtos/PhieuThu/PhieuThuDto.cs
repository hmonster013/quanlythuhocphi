using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.PhieuThu
{
    public class PhieuThuDto
    {
        public int MAPT { get; set; }
        public string? MASV { get; set; }
        public string NIENKHOA { get; set; }
        public int HOCKY { get; set; }        
    }
}