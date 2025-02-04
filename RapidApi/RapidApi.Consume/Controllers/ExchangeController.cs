using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace RapidApi.Consume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task <IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/attraction/getAttractionReviews?id=PR6K7ZswbGBs&page=1"),
                Headers =
    {
        { "x-rapidapi-key", "55a459f09bmshd249e3e8860e1bep1cdef7jsn5bc22f71f12e" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return Ok(body);
            }
        }
    }
}
