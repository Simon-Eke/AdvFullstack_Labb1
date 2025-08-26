using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.DTOs.Table;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AdvFullstack_Labb1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _service;

        public TablesController(ITableService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTables()
        {
            // List of tables
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TableDto>>> GetAvailableTables([FromQuery] int wantedSeats, [FromQuery] DateTime desiredStartTime)
        {
            var tables = await _service.GetAvailableTablesAsync(wantedSeats, desiredStartTime);

            return Ok(tables);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TableDto>> GetTableById(int id)
        {
            var table = await _service.GetTableByIdAsync(id);

            if (table == null)
                return NotFound();

            return Ok(table);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostTable(TableCreateDto newTable)
        {
            int tableId = await _service.CreateTableAsync(newTable);

            return CreatedAtAction(
                nameof(GetTableById),
                new { id = tableId }
                );
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutTable(int id, [FromBody] TableDto tableDto)
        {
            if (id != tableDto.Id)
                return BadRequest();

            var success = await _service.UpdateTableAsync(tableDto);

            if (!success)
                return NotFound();
            
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PatchTable(int id, [FromBody] TablePatchDto patchDto)
        {
            var success = await _service.PatchTableAsync(id, patchDto);

            if (!success)
                return NotFound();
           
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var success = await _service.DeleteTableAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
