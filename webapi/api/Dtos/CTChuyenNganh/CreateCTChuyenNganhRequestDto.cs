using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.CTChuyenNganh
{
    public class CreateCTChuyenNganhRequestDto
    {
        public string? MACN { get; set; }
        public string? MAMH { get; set; }
    }
}