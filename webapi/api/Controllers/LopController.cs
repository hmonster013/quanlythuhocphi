using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Lop;
using api.Dtos.LopHocPhan;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/lop")]
    [ApiController]
    public class LopController : ControllerBase
    {
        private readonly ILopRepository _lopRepository;
        public LopController(ILopRepository lopRepository)
        {
            _lopRepository = lopRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lopModels = await _lopRepository.GetAllAsync();
            var lopDto = lopModels.Select(x => x.ToLopDTO());

            return Ok(lopDto);
        }

        [HttpGet]
        [Route("{maLop}")]
        public async Task<IActionResult> GetDataByID([FromRoute] string maLop)
        {
            var lopModel = await _lopRepository.GetByIdAsync(maLop);

            if (lopModel == null)
            {
                return NotFound();
            }

            return Ok(lopModel.ToLopDTO());
        }

        [HttpGet]
        [Route("khoa/{maKhoa}")]
        public async Task<IActionResult> GetDataByMaKhoa([FromRoute] string maKhoa)
        {
            var lopModels = await _lopRepository.GetDataByMaKhoa(maKhoa);
            var lopDto = lopModels.Select(x => x.ToLopDTO());

            return Ok(lopDto);
        }

        [HttpGet]
        [Route("chuyennganh/{maChuyenNganh}")]
        public async Task<IActionResult> GetDataByMaCN([FromRoute] string maChuyenNganh)
        {
            var lopModels = await _lopRepository.GetDataByMaCN(maChuyenNganh);
            var lopDto = lopModels.Select(x => x.ToLopDTO());

            return Ok(lopDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLopRequestDto createLopRequestDto)
        {
            var lopModel = createLopRequestDto.ToLopFromCreateDTO();
            await _lopRepository.CreateAsync(lopModel);

            return CreatedAtAction(nameof(GetDataByID), new { maLop = lopModel.MALOP }, lopModel.ToLopDTO());
        }

        [HttpPut]
        [Route("{maLop}")] 
        public async Task<IActionResult> Update([FromRoute] string maLop, [FromBody] UpdateLopRequestDto updateLopRequestDto)
        {
            var lopModel = await _lopRepository.UpdateAsync(maLop, updateLopRequestDto);
            
            if (lopModel == null)
            {
                return NotFound();
            }

            return Ok(lopModel);
        }

        [HttpDelete]
        [Route("{maLop}")]
        public async Task<IActionResult> Delete([FromRoute] string maLop)
        {
            var lopModel = await _lopRepository.DeleteAsync(maLop);
            
            if (lopModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}