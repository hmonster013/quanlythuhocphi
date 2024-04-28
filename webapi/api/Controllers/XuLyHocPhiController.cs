using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;       
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/xulyhocphi")]
    [ApiController]
    public class XuLyHocPhiController : ControllerBase
    {
        private readonly IXuLyHocPhiRepository _xuLyHocPhiRepository;

        public XuLyHocPhiController(IXuLyHocPhiRepository xuLyHocPhiRepository)
        {
            _xuLyHocPhiRepository = xuLyHocPhiRepository;
        }

        [HttpGet]
        [Route("sinhvien/sum/{maSinhVien}")]
        public async Task<IActionResult> GetDataTongHocPhiOfSV([FromRoute] string maSinhVien)
        {
            var HocPhiDto = await _xuLyHocPhiRepository.GetDataTongHocPhiOfSV(maSinhVien);

            return Ok(HocPhiDto);
        }

        [HttpGet]
        [Route("sinhvienandhocky/sum/{maSinhVien}/{hocKy}")]
        public async Task<IActionResult> GetDataBySVandHK([FromRoute] string maSinhVien, [FromRoute] int hocKy)
        {
            var hocPhiDto = await _xuLyHocPhiRepository.GetDataBySVandHK(maSinhVien, hocKy);

            if (hocPhiDto == null)
            {
                return NotFound();
            }

            return Ok(hocPhiDto);
        }
    }
}