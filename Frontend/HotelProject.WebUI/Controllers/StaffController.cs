using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IActionResult> StaffIndex() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5193/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
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
        public async Task <IActionResult> AddStaff(CreateStaffDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5193/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StaffIndex");
                
            }
            return View();
        }
        //
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5193/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StaffIndex");

            }
            return View();
        }

        //

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5193/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateStaffDto>(jsonData);
                return View(value);
            }
            return View();
        }

        //
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);    
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"Application/json");

            var responseMessage = await client.PutAsync("http://localhost:5193/api/Staff",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StaffIndex");
            }
            return View();
        }

    }
}
