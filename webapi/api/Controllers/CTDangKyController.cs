using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.CTDangKy;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/ctdangky")]
    [ApiController]
    public class CTDangKyController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICTDangKyRepository _cTDangKyRepository;

        public CTDangKyController(ApplicationDBContext context, ICTDangKyRepository cTDangKyRepository)
        {
            _context = context;
            _cTDangKyRepository = cTDangKyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ctdangkyModels = await _cTDangKyRepository.GetAllAsync();
            var ctdangkyDto = ctdangkyModels.Select(x => x.ToCTDangKyDTO());

            return Ok(ctdangkyDto);
        }

        [HttpGet]
        [Route("{maCTDK}")]
        public async Task<IActionResult> GetDataByID([FromRoute] int maCTDK)
        {
            var ctchuyennganhModel = await _cTDangKyRepository.GetByIdAsync(maCTDK);

            if (ctchuyennganhModel == null)
            {
                return NotFound();
            }

            return Ok(ctchuyennganhModel.ToCTDangKyDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCTDangKyRequestDto createCTDangKyRequestDto)
        {
            var ctdangkyModel = createCTDangKyRequestDto.ToCTDangKyFromCreateDTO();
            await _cTDangKyRepository.CreateAsync(ctdangkyModel);

            return CreatedAtAction(nameof(GetDataByID), new { maCTDK = ctdangkyModel.MACTDK}, ctdangkyModel.ToCTDangKyDTO());
        }

        [HttpPut]
        [Route("{maCTDK}")] 
        public async Task<IActionResult> Update([FromRoute] int maCTDK, [FromBody] UpdateCTDangKyRequestDto updateCTDangKyRequestDto)
        {
            var ctdangkyModel = await _cTDangKyRepository.UpdateAsync(maCTDK, updateCTDangKyRequestDto);

            if (ctdangkyModel == null)
            {
                return NotFound();
            }

            return Ok(ctdangkyModel.ToCTDangKyDTO());
        }

        [HttpDelete]
        [Route("{maCTDK}")]
        public async Task<IActionResult> Delete([FromRoute] int maCTDK)
        {
            var ctdangkyModel = await _cTDangKyRepository.DeleteAsync(maCTDK);

            if (ctdangkyModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{maDangKy}/{maLopHocPhan}")]
        public async Task<IActionResult> DeleteByCondition([FromRoute] int maDangKy, [FromRoute] int maLopHocPhan)
        {
            var ctdangkyModel = await _cTDangKyRepository.DeleteByCondition(maDangKy, maLopHocPhan);

            if (ctdangkyModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}