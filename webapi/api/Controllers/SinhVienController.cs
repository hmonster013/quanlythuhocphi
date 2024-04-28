using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.SinhVien;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/sinhvien")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienRepository _sinhVienRepository;
        public SinhVienController(ISinhVienRepository sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sinhvienModels = await _sinhVienRepository.GetAllAsync();
            var sinhvienDto = sinhvienModels.Select(x => x.ToSinhVienDTO());
            
            return Ok(sinhvienDto);
        }

        [HttpGet]
        [Route("{maSV}")]
        public async Task<IActionResult> GetDataByID([FromRoute] string maSV)
        {
            var sinhvienModel = await _sinhVienRepository.GetByIdAsync(maSV);
            
            if (sinhvienModel == null)
            {
                return NotFound();
            }

            return Ok(sinhvienModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSinhVienRequestDto createSinhVienRequestDto)
        {
            var sinhvienModel = createSinhVienRequestDto.ToSinhVienFromCreateDTO();
            await _sinhVienRepository.CreateAsync(sinhvienModel);
            
            return CreatedAtAction(nameof(GetDataByID), new { maSV = sinhvienModel.MASV }, sinhvienModel.ToSinhVienDTO());
        }

        [HttpPut]
        [Route("{maSV}")] 
        public async Task<IActionResult> Update([FromRoute] string maSV, [FromBody] UpdateSinhVienRequestDto updateSinhVienRequestDto)
        {
            var sinhvienModel = await _sinhVienRepository.UpdateAsync(maSV, updateSinhVienRequestDto);
            
            if (sinhvienModel == null)
            {
                return NotFound();
            }

            return Ok(sinhvienModel);
        }

        [HttpDelete]
        [Route("{maSV}")]
        public async Task<IActionResult> Delete([FromRoute] string maSV)
        {
            var sinhvienModel = await _sinhVienRepository.DeleteAsync(maSV);
            
            if (sinhvienModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}