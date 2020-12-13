using Netflix.Infrastructure.Abstractions.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Netflix.Infrastructure.Services
{
    public class RatingService : IRatingService
    {
        private readonly HttpClient _httpClient;
        private const string BaseAddress = "http://RATINGSERVICE";

        public RatingService(HttpClient httpClient)
        {           
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseAddress);
        }

        public async Task<int> GetRattingStars(Guid moveId)
        {
            return int.Parse(await _httpClient.GetStringAsync($"api/movies/{moveId}/ratting/stars"));
        }
    }
}
