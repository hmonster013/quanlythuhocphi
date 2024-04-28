using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PhieuThu;
using api.Interfaces;
using api.Mappers;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/phieuthu")]
    public class PhieuThuController : ControllerBase
    {
        private readonly IPhieuThuRepository _phieuThuRepository;
        public PhieuThuController(IPhieuThuRepository phieuThuRepository)
        {
            _phieuThuRepository = phieuThuRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var phieuthuModels = await _phieuThuRepository.GetAllAsync();
            var phieuthuDto = phieuthuModels.Select(x => x.ToPhieuThuDTO());

            return Ok(phieuthuDto);
        }

        [HttpGet]
        [Route("{maPT}")]
        public async Task<IActionResult> GetDataByID([FromRoute] int maPT)
        {
            var phieuthuModel = await _phieuThuRepository.GetByIdAsync(maPT);

            if (phieuthuModel == null)
            {
                return NotFound();
            }

            return Ok(phieuthuModel.ToPhieuThuDTO());
        }

        [HttpGet]
        [Route("sinhvien/{maSinhVien}")]
        public async Task<IActionResult> GetDataByMASV([FromRoute] string maSinhVien)
        {
            var phieuthuModels = await _phieuThuRepository.GetDataByMASV(maSinhVien);
            var phieuthuDto = phieuthuModels.Select(x => x.ToPhieuThuDTO());

            return Ok(phieuthuDto);
        }

        [HttpGet]
        [Route("sinhvienandhocky/{maSinhVien}/{hocKy}")]
        public async Task<IActionResult> GetDataByMaSVandHK([FromRoute] string maSinhVien, [FromRoute] int hocKy)
        {
            var phieuthuModel = await _phieuThuRepository.GetDataByMaSVandHK(maSinhVien, hocKy);

            if (phieuthuModel == null)
            {
                return NotFound();
            }

            return Ok(phieuthuModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePhieuThuRequestDto createPhieuThuRequestDto)
        {
            var phieuthuModel = createPhieuThuRequestDto.ToPhieuThuFromCreateDTO();
            await _phieuThuRepository.CreateAsync(phieuthuModel);

            return CreatedAtAction(nameof(GetDataByID), new { maPT = phieuthuModel.MAPT }, phieuthuModel.ToPhieuThuDTO());
        }

        [HttpPut]
        [Route("{maPT}")] 
        public async Task<IActionResult> Update([FromRoute] int maPT, [FromBody] UpdatePhieuThuRequestDto updatePhieuThuRequestDto)
        {
            var phieuthuModel = await _phieuThuRepository.UpdateAsync(maPT, updatePhieuThuRequestDto);
            
            if (phieuthuModel == null)
            {
                return NotFound();
            }

            return Ok(phieuthuModel);
        }

        [HttpDelete]
        [Route("{maPT}")]
        public async Task<IActionResult> Delete([FromRoute] int maPT)
        {
            var phieuthuModel = await _phieuThuRepository.DeleteAsync(maPT);
            
            if (phieuthuModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}