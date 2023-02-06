using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class SwapiApiService
    {
        public static readonly SwapiApiService INSTANCE = new SwapiApiService();

        private HttpClient _client;
        private string rootUrl = "https://swapi.dev/api/";

        public SwapiApiService() 
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(rootUrl);

        }

        public async Task<FilmSearchModel?> SearchFilms(string query, int page = 1)
        {
            string url = $"films?search={Uri.EscapeDataString(query ?? "" )}&page={page}";
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions() 
            { 
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
            var result = JsonSerializer.Deserialize<FilmSearchModel>(content, options);

            return result;
        }

        public async Task<FilmModel?> GetFilm(string id)
        {
            string url = $"films/{id}";

            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
            var result = JsonSerializer.Deserialize<FilmModel>(content, options);

            return result;

        }
    }
}
