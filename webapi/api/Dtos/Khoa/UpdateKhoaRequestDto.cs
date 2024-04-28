using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Khoa
{
    public class UpdateKhoaRequestDto
    {
        public string TENKHOA { get; set; }
        public double DONGIA { get; set; }        
    }
}