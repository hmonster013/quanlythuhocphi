using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.CTPhieuThu;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/ctphieuthu")]
    [ApiController]
    public class CTPhieuThuController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICTPhieuThuRepository _cTPhieuThuRepository;
        public CTPhieuThuController(ApplicationDBContext context, ICTPhieuThuRepository cTPhieuThuRepository)
        {
            _context = context;
            _cTPhieuThuRepository = cTPhieuThuRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ctphieuthuModels = await _cTPhieuThuRepository.GetAllAsync();
            var ctphieuthuDto = ctphieuthuModels.Select(x => x.ToCTPhieuThuDTO());

            return Ok(ctphieuthuDto);
        }

        [HttpGet]
        [Route("{maCTPT}")]
        public async Task<IActionResult> GetDataByID([FromRoute] int maCTPT)
        {
            var ctPhieuThu = await _cTPhieuThuRepository.GetByIdAsync(maCTPT);

            if (ctPhieuThu == null)
            {
                return NotFound();
            }

            return Ok(ctPhieuThu.ToCTPhieuThuDTO());
        }

        [HttpGet]
        [Route("phieuthu/{maPT}")]
        public async Task<IActionResult> GetDataByMaPT([FromRoute] int maPT)
        {
            var ctphieuthuModels = await _cTPhieuThuRepository.GetDataByMaPT(maPT);
            var ctphieuthuDto = ctphieuthuModels.Select(x => x.ToCTPhieuThuDTO());

            return Ok(ctphieuthuDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCTPhieuThuRequestDto createCTPhieuThuRequestDto)
        {
            var ctphieuthuModel = createCTPhieuThuRequestDto.ToCTPhieuThuFromCreateDTO();
            await _cTPhieuThuRepository.CreateAsync(ctphieuthuModel);

            return CreatedAtAction(nameof(GetDataByID), new { maCTPT = ctphieuthuModel.MACTPT }, ctphieuthuModel.ToCTPhieuThuDTO());
        }

        [HttpPut]
        [Route("{maCTPT}")] 
        public async Task<IActionResult> Update([FromRoute] int maCTPT, [FromBody] UpdateCTPhieuThuRequestDto updateCTPhieuThuRequestDto)
        {
            var ctphieuthuModel = await _cTPhieuThuRepository.UpdateAsync(maCTPT, updateCTPhieuThuRequestDto);
            
            if (ctphieuthuModel == null)
            {
                return NotFound();
            }

            return Ok(ctphieuthuModel);
        }

        [HttpDelete]
        [Route("{maCTPT}")]
        public async Task<IActionResult> Delete([FromRoute] int maCTPT)
        {
            var ctphieuthuModel = await _cTPhieuThuRepository.DeleteAsync(maCTPT);

            if (ctphieuthuModel == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}