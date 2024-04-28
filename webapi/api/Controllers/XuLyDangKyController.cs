using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/xulydangky")]
    [ApiController]
    public class XuLyDangKyController : ControllerBase
    {
        private readonly IXuLyDangKyRepository _xuLyDangKyRepository;

        public XuLyDangKyController(IXuLyDangKyRepository xuLyDangKyRepository)
        {
            _xuLyDangKyRepository = xuLyDangKyRepository;
        }

        [HttpGet]
        [Route("1/{maDangKy}/{maSinhVien}/{hocKy}")]
        public async Task<IActionResult> GetDataLHPDaDK([FromRoute] int maDangKy, [FromRoute]  string maSinhVien, [FromRoute]  int hocKy)
        {
            var lopHocPhanQueryDto = await _xuLyDangKyRepository.GetDataLHPDaDK(maDangKy, maSinhVien, hocKy);
            
            return Ok(lopHocPhanQueryDto);
        }

        [HttpGet]
        [Route("0/{maDangKy}/{maSinhVien}/{hocKy}")]
        public async Task<IActionResult> GetDataLHPChuaDK([FromRoute] int maDangKy, [FromRoute]  string maSinhVien, [FromRoute]  int hocKy)
        {
            var lopHocPhanQueryDto = await _xuLyDangKyRepository.GetDataLHPChuaDK(maDangKy, maSinhVien, hocKy);
            
            return Ok(lopHocPhanQueryDto);
        }
    }
}