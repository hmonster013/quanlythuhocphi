using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.MonHoc
{
    public class UpdateMonHocRequestDto
    {
        public string TENMH { get; set; }
        public int HOCKY { get; set; }
        public int SOTINCHI { get; set; }        
    }
}