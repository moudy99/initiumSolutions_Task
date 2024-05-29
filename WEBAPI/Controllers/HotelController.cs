using Microsoft.AspNetCore.Mvc;
using WEBAPI.DTOs;
using WEBAPI.Interfaces;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("GetBranchNames")]
        public async Task<IActionResult> GetBranchNames()
        {
            var result = await _hotelService.GetBranchNamesAsync();
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return StatusCode(500, result);
        }
        [HttpPost("BookRoom")]
        public async Task<IActionResult> BookRoom([FromBody] BookingRequestDto bookingRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new CustomResponseDTO<string>
                {
                    Data = null,
                    Message = "Validation error",
                    Succeeded = false,
                    Errors = errors.ToList()
                });
            }

            var result = await _hotelService.BookRoomAsync(bookingRequest);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return StatusCode(500, result);
        }
    }
}