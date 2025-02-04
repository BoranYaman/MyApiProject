using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models;
using System.Net.Http.Headers;

namespace RapidApi.Consume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task <IActionResult> Index()
        {
            List<ApiMovieViewModel> apiMovieViewModels = new List<ApiMovieViewModel>(); 
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "55a459f09bmshd249e3e8860e1bep1cdef7jsn5bc22f71f12e" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovieViewModels= JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apiMovieViewModels);
            }
        }
    }
}
