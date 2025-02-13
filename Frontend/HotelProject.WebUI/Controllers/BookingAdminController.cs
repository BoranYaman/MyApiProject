﻿using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {  
            _httpClientFactory = httpClientFactory;
        }
        public async Task <IActionResult> BookingAdminIndex()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5193/api/Booking");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
        }
            return View();
    }


        public async Task<IActionResult> ApprovedReservation(ApprovedReservationDto approvedReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(approvedReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5193/api/Booking/bbb", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BookingAdminIndex");
            }

            // Başarısız olursa yine BookingIndex'e yönlendirelim
            TempData["Error"] = "Rezervasyon onaylanırken hata oluştu.";
            return RedirectToAction("BookingAdminIndex");
        }

    }
}

