using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Khoa
{
    public class CreateKhoaRequestDto
    {
        public string MAKHOA { get; set; }
        public string TENKHOA { get; set; }
        public double DONGIA { get; set; }        
    }
}