﻿using HotelProject.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TestimonialIndex()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5193/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        //
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(ResultTestimonialDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5193/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        //
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5193/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        //

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5193/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultTestimonialDto>(jsonData);
                return View(value);
            }
            return View();
        }

        //
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "Application/json");

            var responseMessage = await client.PutAsync("http://localhost:5193/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
