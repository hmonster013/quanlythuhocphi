using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.DangKy;
using ValueObject.XuLyDangKy;

namespace BusinessLogicLayer
{
    public class XULYDANGKYBUS
    {
        private XULYDANGKYDAO dao = new XULYDANGKYDAO();
        public async Task<List<LopHocPhanQueryDto>> GetDataLHPDaDK(DANGKY obj)
        {
            return await dao.GetDataLHPDaDK(obj);
        }

        public async Task<List<LopHocPhanQueryDto>> GetDataLHPChuaDK(DANGKY obj)
        {
            return await dao.GetDataLHPChuaDK(obj);
        }
    }
}
