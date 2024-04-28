using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Lop
{
    public class CreateLopRequestDto
    {
        public string MALOP { get; set; }
        public string? MACN { get; set; }        
    }
}