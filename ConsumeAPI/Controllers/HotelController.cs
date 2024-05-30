using ConsumeAPI.Repository;
using ConsumeAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _hotelRepository.GetBranchNamesAsync();
            ViewBag.HotelBranches = list;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookRoom([FromBody] BookingViewModel bookingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _hotelRepository.BookRoomAsync(bookingViewModel);

            if (response.Succeeded)
            {
                return Ok(response);
            }
            else
            {
                ViewBag.Message = response.Message;
            }

            return View("Index");
        }

    }
}