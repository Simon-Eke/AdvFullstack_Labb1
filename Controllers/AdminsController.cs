using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.DTOs.Admin;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvFullstack_Labb1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _service;
        public AdminsController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AdminDto>>> GetAll()
        {
            var admins = await _service.GetAllAsync();

            return Ok(admins);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdminDto>> GetById(int id)
        {
            var admin = await _service.GetByIdAsync(id);

            if (admin == null)
                return NotFound();

            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create(AdminCreateDto newAdmin)
        {
            int adminId = await _service.CreateAsync(newAdmin);

            return CreatedAtAction(
                nameof(GetById),
                new { id = adminId },
                new { id = adminId }
                );
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] AdminPutDto adminDto)
        {
            if (id != adminDto.Id)
                return BadRequest();

            var success = await _service.UpdateAsync(adminDto);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Patch(int id, [FromBody] AdminPatchDto patchDto)
        {
            var success = await _service.PatchAsync(id, patchDto);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
