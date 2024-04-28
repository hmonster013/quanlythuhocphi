using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValueObject.PhieuThu
{
    public class CreatePhieuThuRequestDto
    {
        public string MASV { get; set; }
        public string NIENKHOA { get; set; }
        public int HOCKY { get; set; }
    }
}