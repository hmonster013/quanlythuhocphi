using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValueObject.MonHoc
{
    public class CreateMonHocRequestDto
    {
        public string MAMH { get; set; }
        public string TENMH { get; set; }
        public int HOCKY { get; set; }
        public int SOTINCHI { get; set; }        
    }
}