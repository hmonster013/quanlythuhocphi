using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValueObject.ChuyenNganh
{
    public class CreateChuyenNganhRequestDto
    {
        public string MACN { get; set; }
        public string TENCN { get; set; }
        public string MAKHOA { get; set; }
    }
}