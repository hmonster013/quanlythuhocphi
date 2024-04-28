using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.CTChuyenNganh;
using api.Interface;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/ctchuyennganh")]
    [ApiController]
    public class CTChuyenNganhController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICTChuyenNganhRepository _cTChuyenNganhRepository;

        public CTChuyenNganhController(ApplicationDBContext context, ICTChuyenNganhRepository cTChuyenNganhRepository)
        {
            _context = context;
            _cTChuyenNganhRepository = cTChuyenNganhRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ctchuyennganhModels = await _cTChuyenNganhRepository.GetAllAsync();
            var ctchuyennganhDto = ctchuyennganhModels.Select(x => x.ToCTChuyenNganhDTO());

            return Ok(ctchuyennganhDto);
        }

        [HttpGet]
        [Route("{maCTCN}")]
        public async Task<IActionResult> GetDataByID([FromRoute] int maCTCN)
        {
            var ctchuyennganhModel = await _cTChuyenNganhRepository.GetByIdAsync(maCTCN);
            
            if (ctchuyennganhModel == null)
            {
                return NotFound();
            }

            return Ok(ctchuyennganhModel.ToCTChuyenNganhDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCTChuyenNganhRequestDto createCTChuyenNganhRequestDto)
        {
            var ctchuyennganhModel = createCTChuyenNganhRequestDto.ToCTChuyenNganhFromCreateDTO();
            await _cTChuyenNganhRepository.CreateAsync(ctchuyennganhModel);

            return CreatedAtAction(nameof(GetDataByID), new { maCTCN = ctchuyennganhModel.MACTCN}, ctchuyennganhModel.ToCTChuyenNganhDTO());
        }

        [HttpPut]
        [Route("{maCTCN}")] 
        public async Task<IActionResult> Update([FromRoute] int maCTCN, [FromBody] UpdateCTChuyenNganhRequestDto updateCTChuyenNganhRequestDto)
        {
            var ctchuyennganhModel = await _cTChuyenNganhRepository.UpdateAsync(maCTCN, updateCTChuyenNganhRequestDto);

            if (ctchuyennganhModel == null)
            {
                return NotFound();
            }
            
            return Ok();
        }

        [HttpDelete]
        [Route("{maCTCN}")]
        public async Task<IActionResult> Delete([FromRoute] int maCTCN)
        {
            var ctchuyennganhModel = await _cTChuyenNganhRepository.DeleteAsync(maCTCN);

            if (ctchuyennganhModel == null)
            {
                return NotFound();
            }

            return Ok(ctchuyennganhModel.ToCTChuyenNganhDTO());
        }

        [HttpDelete]
        [Route("monhoc/{maMonHoc}")]
        public async Task<IActionResult> DeleteByMaMH([FromRoute] string maMonHoc)
        {
            var ctchuyennganhModel = await _cTChuyenNganhRepository.DeleteByMaMHAsync(maMonHoc);

            if (ctchuyennganhModel == null)
            {
                return NotFound();
            }

            return Ok(ctchuyennganhModel.ToCTChuyenNganhDTO());
        }
    }
}