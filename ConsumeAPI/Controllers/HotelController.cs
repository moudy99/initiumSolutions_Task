using ConsumeAPI.Repository;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _hotelRepository.GetBranchNamesAsync();
            return View(list);
        }
    }
}