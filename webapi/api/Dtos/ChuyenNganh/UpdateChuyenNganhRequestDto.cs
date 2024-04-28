using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ChuyenNganh
{
    public class UpdateChuyenNganhRequestDto
    {
        public string TENCN { get; set; }
        public string? MAKHOA { get; set; }
    }
}