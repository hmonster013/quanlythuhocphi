using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.LopHocPhan;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/lophocphan")]
    [ApiController]
    public class LopHocPhanController : ControllerBase
    {
        private readonly ILopHocPhanRepository _lopHocPhanRepository;
        public LopHocPhanController(ILopHocPhanRepository lopHocPhanRepository)
        {
            _lopHocPhanRepository = lopHocPhanRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lophocphanModels = await _lopHocPhanRepository.GetAllAsync();
            var lophocphanDto = lophocphanModels.Select(x => x.ToLopHocPhanDTO());

            return Ok(lophocphanDto);
        }

        [HttpGet]
        [Route("{maLHP}")]
        public async Task<IActionResult> GetDataByID([FromRoute] int maLHP)
        {
            var lophocphanModel = await _lopHocPhanRepository.GetByIdAsync(maLHP);
            
            if (lophocphanModel == null)
            {
                return NotFound();
            }

            return Ok(lophocphanModel);
        }

        [HttpGet]
        [Route("chuyennganh/{maChuyenNganh}")]
        public async Task<IActionResult> GetDataByChuyenNganh([FromRoute] string maChuyenNganh)
        {
            var lophocphanModels = await _lopHocPhanRepository.GetDataByChuyenNganh(maChuyenNganh);
            var lophocphanDto = lophocphanModels.Select(x => x.ToLopHocPhanDTO());

            return Ok(lophocphanDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLopHocPhanRequestDto createLopHocPhanRequestDto)
        {
            var lophocphanModel = createLopHocPhanRequestDto.ToLopHocPhanFromCreateDTO();
            await _lopHocPhanRepository.CreateAsync(lophocphanModel);

            return CreatedAtAction(nameof(GetDataByID), new { maLHP = lophocphanModel.MALHP }, lophocphanModel.ToLopHocPhanDTO());
        }

        [HttpPut]
        [Route("{maLHP}")] 
        public async Task<IActionResult> Update([FromRoute] int maLHP, [FromBody] UpdateLopHocPhanRequestDto updateLopHocPhanRequestDto)
        {
            var lophocphanModel = await _lopHocPhanRepository.UpdateAsync(maLHP, updateLopHocPhanRequestDto);
            
            if (lophocphanModel == null)
            {
                return NotFound();
            }

            return Ok(lophocphanModel);
        }

        [HttpDelete]
        [Route("{maLHP}")]
        public async Task<IActionResult> Delete([FromRoute] int maLHP)
        {
            var lophocphanModel = await _lopHocPhanRepository.DeleteAsync(maLHP);
            
            if (lophocphanModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}