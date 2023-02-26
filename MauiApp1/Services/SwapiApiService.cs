using MauiApp1.Models;
using MauiApp1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class SwapiApiService : ISwapiApiService
    {

        private HttpClient _client;
        private string rootUrl = "https://swapi.dev/api/";
        private JsonSerializerOptions _serializationOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Converters = { 
                new ExtendedDoubleJsonConverter()
            }

        };

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
            var result = JsonSerializer.Deserialize<FilmSearchModel>(content, _serializationOptions);

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

        public async Task<VehiclesSeachModel> SearchVehicles(string query, int page = 1)
        {
            string url = $"vehicles?search={Uri.EscapeDataString(query ?? "")}&page={page}";
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<VehiclesSeachModel>(content, _serializationOptions);

            return result;
        }

        public async Task<VehiclesModel> GetVehicle(string id)
        {
            string url = $"vehicles/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<VehiclesModel>(content, _serializationOptions);

            return result;
        }

        public async Task<PeopleSearchModel?> SearchPeople(string query, int page = 1)
        {
            string url = $"people?search={Uri.EscapeDataString(query ?? "")}&page={page}";
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PeopleSearchModel>(content, _serializationOptions);
            return result;
        }

        public async Task<PeopleModel?> GetPeople(string id)
        {
            string url = $"people/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<PeopleModel>(content, _serializationOptions);

            return result;
        }

        public async Task<StarshipsSearchModel> SearchStarship(string query, int page = 1)
        {
            string url = $"starships?search={Uri.EscapeDataString(query ?? "")}&page={page}";
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<StarshipsSearchModel>(content, _serializationOptions);
            return result;
        }

        public async Task<StarshipModel> GetStarship(string id)
        {
            string url = $"starships/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<StarshipModel>(content, _serializationOptions);

            return result;
        }

        public async Task<SpeciesSearchModel> SearchSpecies(string query, int page = 1)
        {
            string url = $"species?search={Uri.EscapeDataString(query ?? "")}&page={page}";
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SpeciesSearchModel>(content, _serializationOptions);
            return result;
        }

        public async Task<SpeciesModel> GetSpecies(string id)
        {
            string url = $"species/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<SpeciesModel>(content, _serializationOptions);

            return result;
        }

        public async Task<PlanetSearchModel> SearchPlanets(string query, int page = 1)
        {
            string url = $"planets?search={Uri.EscapeDataString(query ?? "")}&page={page}";
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PlanetSearchModel>(content, _serializationOptions);
            return result;
        }

        public async Task<PlanetModel> GetPlanets(string id)
        {
            string url = $"planets/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<PlanetModel>(content, _serializationOptions);

            return result;
        }
    }
}
