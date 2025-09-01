using AdvFullstack_Labb1.Models.DTOs.MenuItem;
using AdvFullstack_Labb1.Models.DTOs.Table;
using AdvFullstack_Labb1.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvFullstack_Labb1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _service;
        public MenuItemsController(IMenuItemService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MenuItemDto>>> GetAll()
        {
            var menuItems = await _service.GetAllAsync();

            return Ok(menuItems);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MenuItemDto>> GetById(int id)
        {
            var menuItem = await _service.GetByIdAsync(id);

            if (menuItem == null)
                return NotFound();

            return Ok(menuItem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create(MenuItemCreateDto newMenuItem)
        {
            int menuItemId = await _service.CreateAsync(newMenuItem);

            return CreatedAtAction(
                nameof(GetById),
                new { id = menuItemId },
                new { id = menuItemId }
                );
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] MenuItemDto menuItemDto)
        {
            if (id != menuItemDto.Id)
                return BadRequest();

            var success = await _service.UpdateAsync(menuItemDto);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Patch(int id, [FromBody] MenuItemPatchDto patchDto)
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
