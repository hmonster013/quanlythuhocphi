using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.NguoiDung;
using api.Interfaces;
using api.Mappers;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/nguoidung")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly INguoiDungRepository _nguoiDungRepository;

        public NguoiDungController(ApplicationDBContext context, INguoiDungRepository nguoiDungRepository)
        {
            _context = context;
            _nguoiDungRepository = nguoiDungRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nguoidungs = await _nguoiDungRepository.GetAllAsync();
            var nguoidungDto = nguoidungs.Select(x => x.ToNguoiDungDTO());

            return Ok(nguoidungDto);
        }

        [HttpGet]
        [Route("{tentaikhoan}")]
        public async Task<IActionResult> GetDataByID([FromRoute] string tentaikhoan)
        {
            var nguoidung = await _nguoiDungRepository.GetByIdAsync(tentaikhoan);

            if (nguoidung == null)
            {
                return NotFound();
            }

            return Ok(nguoidung.ToNguoiDungDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNguoiDungRequestDto createNguoiDungRequestDto)
        {
            var nguoidungModel = createNguoiDungRequestDto.ToNguoiDungFromCreateDTO();
            await _nguoiDungRepository.CreateAsync(nguoidungModel);

            return CreatedAtAction(nameof(GetDataByID), new { tentaikhoan = nguoidungModel.TENTAIKHOAN }, nguoidungModel.ToNguoiDungDTO());
        }

        [HttpPut]
        [Route("{tentaikhoan}")] 
        public async Task<IActionResult> Update([FromRoute] string tentaikhoan, [FromBody] UpdateNguoiDungRequestDto updateNguoiDungRequestDto)
        {
            var nguoidungModel = await _nguoiDungRepository.UpdateAsync(tentaikhoan, updateNguoiDungRequestDto);

            if (nguoidungModel == null)
            {
                return NotFound();
            }

            return Ok(nguoidungModel.ToNguoiDungDTO());
        }

        [HttpDelete]
        [Route("{tentaikhoan}")]
        public async Task<IActionResult> Delete([FromRoute] string tentaikhoan)
        {
            var nguoidungModel = await _nguoiDungRepository.DeleteAsync(tentaikhoan);

            if (nguoidungModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}