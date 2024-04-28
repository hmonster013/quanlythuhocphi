using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.GiangVien;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/giangvien")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienRepository _giangVienRepository;
        public GiangVienController(IGiangVienRepository giangVienRepository)
        {
            _giangVienRepository = giangVienRepository;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var giangvienModels = await _giangVienRepository.GetAllAsync();
            var giangvienDto = giangvienModels.Select(x => x.ToGiangVienDTO());

            return Ok(giangvienDto);
        }

        [HttpGet]
        [Route("{maGV}")]
        public async Task<IActionResult> GetDataByID([FromRoute] string maGV)
        {
            var giangvienModel = await _giangVienRepository.GetByIdAsync(maGV);

            if (giangvienModel == null)
            {
                return NotFound();
            }

            return Ok(giangvienModel.ToGiangVienDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGiangVienRequestDto createGiangVienRequestDto)
        {
            var giangvienModel = createGiangVienRequestDto.ToGiangVienFromCreateDTO();
            await _giangVienRepository.CreateAsync(giangvienModel);

            return CreatedAtAction(nameof(GetDataByID), new { maGV = giangvienModel.MAGV }, giangvienModel.ToGiangVienDTO());
        }

        [HttpPut]
        [Route("{maGV}")] 
        public async Task<IActionResult> Update([FromRoute] string maGV, [FromBody] UpdateGiangVienRequestDto updateGiangVienRequestDto)
        {
            var giangvienModel = await _giangVienRepository.UpdateAsync(maGV, updateGiangVienRequestDto);

            if (giangvienModel == null)
            {
                return NotFound();
            }

            return Ok(giangvienModel.ToGiangVienDTO());
        }

        [HttpDelete]
        [Route("{maGV}")]
        public async Task<IActionResult> Delete([FromRoute] string maGV)
        {
            var giangvienModel = await _giangVienRepository.DeleteAsync(maGV);
            
            if (giangvienModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}