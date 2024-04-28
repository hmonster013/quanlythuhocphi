using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ChuyenNganh;
using api.Interfaces;
using api.Mappers;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/chuyennganh")]
    [ApiController]
    public class ChuyenNganhController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IChuyenNganhRepository _chuyenNganhRepository;
        public ChuyenNganhController(ApplicationDBContext context, IChuyenNganhRepository chuyenNganhRepository)
        {
            _context = context;
            _chuyenNganhRepository = chuyenNganhRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chuyennganhs = await _chuyenNganhRepository.GetAllAsync();
            var chuyennganhDto = chuyennganhs.Select(x => x.ToChuyenNganhDTO());

            return Ok(chuyennganhDto);
        }

        [HttpGet]
        [Route("{maCN}")]
        public async Task<IActionResult> GetDataByID([FromRoute] string maCN)
        {
            var chuyennganhModel = await _chuyenNganhRepository.GetByIdAsync(maCN);

            if (chuyennganhModel == null)
            {
                return NotFound();
            }

            return Ok(chuyennganhModel.ToChuyenNganhDTO());
        }

        [HttpGet]
        [Route("khoa/{maKhoa}")]
        public async Task<IActionResult> GetDataByMaKhoa([FromRoute] string maKhoa)
        {
            var chuyennganhModels = await _chuyenNganhRepository.GetDataByMaKhoa(maKhoa);
            var chuyennganhDto  = chuyennganhModels.Select(x => x.ToChuyenNganhDTO());

            return Ok(chuyennganhDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChuyenNganhRequestDto createChuyenNganhRequestDto)
        {
            var chuyennganhModel = createChuyenNganhRequestDto.ToChuyenNganhFromCreateDTO();
            await _chuyenNganhRepository.CreateAsync(chuyennganhModel);

            return CreatedAtAction(nameof(GetDataByID), new { maCN = chuyennganhModel.MACN}, chuyennganhModel.ToChuyenNganhDTO());
        }

        [HttpPut]
        [Route("{maCN}")] 
        public async Task<IActionResult> Update([FromRoute] string maCN, [FromBody] UpdateChuyenNganhRequestDto updateChuyenNganhRequestDto)
        {
            var chuyennganhModel = await _chuyenNganhRepository.UpdateAsync(maCN, updateChuyenNganhRequestDto);

            if (chuyennganhModel == null)
            {
                return NotFound();
            }

            return Ok(chuyennganhModel.ToChuyenNganhDTO());
        }

        [HttpDelete]
        [Route("{maCN}")]
        public async Task<IActionResult> Delete([FromRoute] string maCN)
        {
            var chuyennganhModel = await _chuyenNganhRepository.DeleteAsync(maCN);

            if (chuyennganhModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}