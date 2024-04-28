using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject.LopHocPhan;
using ValueObject;

namespace Mappers
{
    public static class LopHocPhanMappers
    {
        public static CreateLopHocPhanRequestDto ToCreateDTOFromLopHocPhan(this LOPHOCPHAN lopHocPhan)
        {
            return new CreateLopHocPhanRequestDto
            {
                NIENKHOA = lopHocPhan.NIENKHOA,
                HOCKY = lopHocPhan.HOCKY,
                MAMH = lopHocPhan.MAMH,
                MAGV = lopHocPhan.MAGV,
                MACN = lopHocPhan.MACN,
                HUYLOP = lopHocPhan.HUYLOP
            };
        }

        public static UpdateLopHocPhanRequestDto ToUpdateDTOFromLopHocPhan(this LOPHOCPHAN lopHocPhan)
        {
            return new UpdateLopHocPhanRequestDto
            {
                NIENKHOA = lopHocPhan.NIENKHOA,
                HOCKY = lopHocPhan.HOCKY,
                MAMH = lopHocPhan.MAMH,
                MAGV = lopHocPhan.MAGV,
                MACN = lopHocPhan.MACN,
                HUYLOP = lopHocPhan.HUYLOP
            };
        }
    }
}