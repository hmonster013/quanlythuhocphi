using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using api.Dtos.MonHoc;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/monhoc")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocRepository _monHocRepository;

        public MonHocController(IMonHocRepository monHocRepository)
        {
            _monHocRepository = monHocRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var monhocModels = await _monHocRepository.GetAllAsync();
            var monhocDto = monhocModels.Select(x => x.ToMonHocDTO());

            return Ok(monhocDto);
        }

        [HttpGet]
        [Route("{maMH}")]
        public async Task<IActionResult> GetDataByID([FromRoute] string maMH)
        {
            var monhocModel = await _monHocRepository.GetByIdAsync(maMH);

            if (monhocModel == null)
            {
                return NotFound();
            }

            return Ok(monhocModel.ToMonHocDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMonHocRequestDto createMonHocRequestDto)
        {
            var monhocModel = createMonHocRequestDto.ToMonHocFromCreateDTO();
            await _monHocRepository.CreateAsync(monhocModel);

            return CreatedAtAction(nameof(GetDataByID), new { maMH = monhocModel.MAMH }, monhocModel.ToMonHocDTO());
        }

        [HttpPut]
        [Route("{maMH}")] 
        public async Task<IActionResult> Update([FromRoute] string maMH, [FromBody] UpdateMonHocRequestDto updateMonHocRequestDto)
        {
            var monhocModel = await _monHocRepository.UpdateAsync(maMH, updateMonHocRequestDto);
            
            if (monhocModel == null)
            {
                return NotFound();
            }

            return Ok(monhocModel.ToMonHocDTO());
        }

        [HttpDelete]
        [Route("{maMH}")]
        public async Task<IActionResult> Delete([FromRoute] string maMH)
        {
            var monhocModel = await _monHocRepository.DeleteAsync(maMH);
            
            if (monhocModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}