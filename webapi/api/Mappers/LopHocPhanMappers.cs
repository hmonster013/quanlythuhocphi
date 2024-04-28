using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.LopHocPhan;
using api.Models;

namespace api.Mappers
{
    public static class LopHocPhanMappers
    {
        public static LopHocPhanDto ToLopHocPhanDTO(this LOPHOCPHAN lophocphanModel)
        {
            return new LopHocPhanDto
            {
                MALHP = lophocphanModel.MALHP,
                NIENKHOA = lophocphanModel.NIENKHOA,
                HOCKY = lophocphanModel.HOCKY,
                MAMH = lophocphanModel.MAMH,
                MAGV = lophocphanModel.MAGV,
                MACN = lophocphanModel.MACN,
                HUYLOP = lophocphanModel.HUYLOP
            };
        }

        public static LOPHOCPHAN ToLopHocPhanFromCreateDTO(this CreateLopHocPhanRequestDto createLopHocPhanRequestDto)
        {
            return new LOPHOCPHAN
            {
                NIENKHOA = createLopHocPhanRequestDto.NIENKHOA,
                HOCKY = createLopHocPhanRequestDto.HOCKY,
                MAMH = createLopHocPhanRequestDto.MAMH,
                MAGV = createLopHocPhanRequestDto.MAGV,
                MACN = createLopHocPhanRequestDto.MACN,
                HUYLOP = createLopHocPhanRequestDto.HUYLOP
            };
        }
    }
}