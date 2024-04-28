using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/chuongtrinhhoc")]
    [ApiController]
    public class ChuongTrinhHocController : ControllerBase
    {
        private readonly IChuongTrinhHocRepository _chuongTrinhHocRepository;

        public ChuongTrinhHocController(IChuongTrinhHocRepository chuongTrinhHocRepository)
        {
            _chuongTrinhHocRepository = chuongTrinhHocRepository;
        }

        // Lấy danh sách môn học không thuộc chuyên ngành 
        [HttpGet]
        [Route("0/{maChuyenNganh}")]
        public async Task<IActionResult> GetDataNotInChuyenNganh([FromRoute] string maChuyenNganh) 
        {
            var monhoc = await _chuongTrinhHocRepository.GetDataNotInChuyenNganh(maChuyenNganh);

            return Ok(monhoc);
        }

        // Lấy danh sách môn học thuộc chuyên ngành 
        [HttpGet]
        [Route("1/{maChuyenNganh}")]
        public async Task<IActionResult> GetDataByChuyenNganh([FromRoute] string maChuyenNganh) 
        {
            var monhoc = await _chuongTrinhHocRepository.GetDataByChuyenNganh(maChuyenNganh);

            return Ok(monhoc);
        }

        [HttpGet]
        [Route("sinhvien/{maSinhVien}")]
        public async Task<IActionResult> GetDataBySinhVien([FromRoute] string maSinhVien)
        {
            var monhocModels = await _chuongTrinhHocRepository.GetDataBySinhVien(maSinhVien);

            return Ok(monhocModels);
        }

        [HttpGet]
        [Route("sinhvienandhocky/{maSinhVien}/{hocKy}")]
        public async Task<IActionResult> GetDataBySVHocKy([FromRoute] string maSinhVien, [FromRoute] int hocKy)
        {
            var monhocModels = await _chuongTrinhHocRepository.GetDataBySVHocKy(maSinhVien, hocKy);

            return Ok(monhocModels);
        }
    }
}