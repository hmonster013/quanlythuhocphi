using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValueObject.NguoiDung
{
    public class CreateNguoiDungRequestDto
    {
        public string TENTAIKHOAN { get; set; }
        public string MATKHAU { get; set; }
        public string QUYEN { get; set; }
    }
}