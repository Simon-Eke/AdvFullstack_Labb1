using AdvFullstack_Labb1.Models.DTOs.Booking;
using AdvFullstack_Labb1.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvFullstack_Labb1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;
        public BookingsController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BookingDto>>> GetAll()
        {
            var bookings = await _service.GetAllAsync();

            return Ok(bookings);
        }

        [HttpGet("with-details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BookingWithDetailsDto>>> GetAllWithDetailsAsync()
        {
            var bookings = await _service.GetAllWithDetailsAsync();

            return Ok(bookings);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookingDto>> GetById(int id)
        {
            var booking = await _service.GetByIdAsync(id);

            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [HttpGet("{id:int}/with-details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookingWithDetailsDto>> GetByIdWithDetailsAsync(int id)
        {
            var booking = await _service.GetByIdWithDetailsAsync(id);

            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> ConfirmBooking(BookingRequestDto request)
        {
            var success = await _service.TryCreateBookingAsync(request);

            if (!success)
                return Conflict();

            return Ok();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingUpdateRequestDto request)
        {
            if (id != request.Id)
                return BadRequest();

            var success = await _service.TryUpdateBookingAsync(request);

            if (!success)
                return Conflict();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Patch(int id, [FromBody] BookingPatchDto patchDto)
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
