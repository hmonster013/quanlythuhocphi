using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DangKy;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/dangky")]
    [ApiController]
    public class DangKyController : ControllerBase
    {
        private readonly IDangKyRepository _dangKyRepository;
        
        public DangKyController(IDangKyRepository dangKyRepository)
        {
            _dangKyRepository = dangKyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dangkyModels = await _dangKyRepository.GetAllAsync();
            var dangkyDto = dangkyModels.Select(x => x.ToDangKyDTO());

            return Ok(dangkyDto);
        }

        [HttpGet]
        [Route("{maDK}")]
        public async Task<IActionResult> GetDataByID([FromRoute] int maDK)
        {
            var dangkyModel = await _dangKyRepository.GetByIdAsync(maDK);

            if (dangkyModel == null)
            {
                return NotFound();
            }

            return Ok(dangkyModel.ToDangKyDTO());
        }

        [HttpGet]
        [Route("sinhvien/{maSinhVien}")]
        public async Task<IActionResult> GetDataByMASV([FromRoute] string maSinhVien)
        {
            var dangkyModels = await _dangKyRepository.GetDataByMASV(maSinhVien);
            var dangkyDto = dangkyModels.Select(x => x.ToDangKyDTO());

            return Ok(dangkyDto);
        }

        [HttpGet]
        [Route("sinhvien/{maSinhVien}/{hocKy}")]
        public async Task<IActionResult> GetDataByMASVandHOCKY([FromRoute] string maSinhVien, [FromRoute] int hocKy)
        {
            var dangkyModel = await _dangKyRepository.GetDataByMASVandHOCKY(maSinhVien, hocKy);

            if (dangkyModel == null)
            {
                return NotFound();
            }

            return Ok(dangkyModel.ToDangKyDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDangKyRequestDto createDangKyRequestDto)
        {
            var dangkyModel = createDangKyRequestDto.ToDangKyFromCreateDTO();
            await _dangKyRepository.CreateAsync(dangkyModel);

            return CreatedAtAction(nameof(GetDataByID), new { maDK = dangkyModel.MADK }, dangkyModel.ToDangKyDTO());
        }

        [HttpPut]
        [Route("{maDK}")] 
        public async Task<IActionResult> Update([FromRoute] int maDK, [FromBody] UpdateDangKyRequestDto updateDangKyRequestDto)
        {
            var dangkyModel = await _dangKyRepository.UpdateAsync(maDK, updateDangKyRequestDto);
            
            if (dangkyModel == null)
            {
                return NotFound();
            }

            return Ok(dangkyModel.ToDangKyDTO());
        }

        [HttpDelete]
        [Route("{maDK}")]
        public async Task<IActionResult> Delete([FromRoute] int maDK)
        {
            var dangkyModel = await _dangKyRepository.DeleteAsync(maDK);
            
            if (dangkyModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}