using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvFullstack_Labb1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public IActionResult GetTables()
        {
            // List of tables
            return Ok();
        }

        [HttpPost]
        public IActionResult PostTable()
        {
            // Create new table and return a dto?
            return Created();
        }

        [HttpPut]
        public IActionResult PutTable()
        {
            // Apply change
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTable()
        {
            // Delete
            return Ok();
        }
    }
}
