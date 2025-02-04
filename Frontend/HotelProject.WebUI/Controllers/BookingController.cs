using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult BookingIndex()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return View("BookingIndex", createBookingDto); // Doğru sayfayı döndür
            }

            createBookingDto.Status = "Onay Bekliyor";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5193/api/Booking", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BookingIndex"); // Form sonrası sayfaya yönlendir
            }

            return View("BookingIndex", createBookingDto);
        }

    }
}

