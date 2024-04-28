using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.GiangVien
{
    public class UpdateGiangVienRequestDto
    {
        public string? MAKHOA { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public string HOCHAM { get; set; }        
    }
}