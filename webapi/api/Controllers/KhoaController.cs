using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Khoa;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/khoa")]
    [ApiController]
    public class KhoaController : ControllerBase
    {
        private readonly IKhoaRepository _khoaRepository;
        public KhoaController(IKhoaRepository khoaRepository)
        {
            _khoaRepository = khoaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var khoaModels = await _khoaRepository.GetAllAsync();
            var khoaDto = khoaModels.Select(x => x.ToKhoaDTO());

            return Ok(khoaDto);
        }

        [HttpGet]
        [Route("{maKhoa}")]
        public async Task<IActionResult> GetDataByID([FromRoute] string maKhoa)
        {
            var khoamodel = await _khoaRepository.GetByIdAsync(maKhoa);

            if (khoamodel == null)
            {
                return NotFound();
            }

            return Ok(khoamodel.ToKhoaDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateKhoaRequestDto createKhoaRequestDto)
        {
            var khoaModel = createKhoaRequestDto.ToKhoaFromCreateDTO();
            await _khoaRepository.CreateAsync(khoaModel);
            return CreatedAtAction(nameof(GetDataByID), new { maKhoa = khoaModel.MAKHOA }, khoaModel.ToKhoaDTO());
        }

        [HttpPut]
        [Route("{maKhoa}")] 
        public async Task<IActionResult> Update([FromRoute] string maKhoa, [FromBody] UpdateKhoaRequestDto updateKhoaRequestDto)
        {
            var khoaModel = await _khoaRepository.UpdateAsync(maKhoa, updateKhoaRequestDto);
            
            if (khoaModel == null)
            {
                return NotFound();
            }

            return Ok(khoaModel);
        }

        [HttpDelete]
        [Route("{maKhoa}")]
        public async Task<IActionResult> Delete([FromRoute] string maKhoa)
        {
            var khoaModel = await _khoaRepository.DeleteAsync(maKhoa);

            if (khoaModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}