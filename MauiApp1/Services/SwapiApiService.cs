using MauiApp1.Models;
using MauiApp1.Utility;
using System.Text.Json;
using System.Text.Json.Serialization;
using MauiApp1.Models.Enums;

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
                new ExtendedDoubleJsonConverter(),
                new ExtendedIntJsonConverter()
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
            foreach (var item in result.Results)
            {
                item.EntityId = GetFilmIdFromUrl(item.Url);
            }

            return result;
        }

        public async Task<FilmModel?> GetFilm(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            string url = $"films/{id}";

            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<FilmModel>(content, _serializationOptions);
            result.EntityId = id;
            result.RelatedEntities = new List<EntityIdentifier>();

            foreach (string entityUrl in result.Vehicles) 
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Vehicle, GetVehiclesIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Species)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Species, GetSpeciesIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Starships)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Starship, GetStarshipsIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Characters)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.People, GetPeopleIdFromUrl(entityUrl)));
            }

            return result;

        }

        public async Task<VehiclesSearchModel?> SearchVehicles(string query, int page = 1)
        {
            string url = $"vehicles?search={Uri.EscapeDataString(query ?? "")}&page={page}";
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<VehiclesSearchModel>(content, _serializationOptions);
            foreach (var item in result.Results)
            {
                item.EntityId = GetVehiclesIdFromUrl(item.Url);
            }
            return result;
        }

        public async Task<VehicleModel> GetVehicle(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            string url = $"vehicles/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<VehicleModel>(content, _serializationOptions);
            result.EntityId = id;
            result.RelatedEntities = new List<EntityIdentifier>();

            foreach (string entityUrl in result.Films)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Film, GetFilmIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Pilots)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.People, GetPeopleIdFromUrl(entityUrl)));
            }
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
            foreach (var item in result.Results)
            {
                item.EntityId = GetPeopleIdFromUrl(item.Url);
            }
            return result;
        }

        public async Task<PeopleModel?> GetPeople(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            string url = $"people/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<PeopleModel>(content, _serializationOptions);
            result.EntityId = id;
            result.RelatedEntities = new List<EntityIdentifier>();


            foreach (string entityUrl in result.Films)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Film, GetFilmIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Species)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.People, GetSpeciesIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Vehicles)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Vehicle, GetVehiclesIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Starships)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Starship, GetStarshipsIdFromUrl(entityUrl)));
            }
            return result;
        }

        public async Task<StarshipsSearchModel> SearchStarships(string query, int page = 1)
        {
            string url = $"starships?search={Uri.EscapeDataString(query ?? "")}&page={page}";
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<StarshipsSearchModel>(content, _serializationOptions);
            foreach (var item in result.Results)
            {
                item.EntityId = GetStarshipsIdFromUrl(item.Url);
            }
            return result;
        }

        public async Task<StarshipModel> GetStarship(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            string url = $"starships/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<StarshipModel>(content, _serializationOptions);
            result.EntityId = id;
            result.RelatedEntities = new List<EntityIdentifier>();

            foreach (string entityUrl in result.Films)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Film, GetPeopleIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Pilots)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.People, GetPeopleIdFromUrl(entityUrl)));
            }

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
            foreach (var item in result.Results)
            {
                item.EntityId = GetSpeciesIdFromUrl(item.Url);
            }
            return result;
        }

        public async Task<SpeciesModel> GetSpecies(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            string url = $"species/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<SpeciesModel>(content, _serializationOptions);
            result.EntityId = id;
            result.RelatedEntities = new List<EntityIdentifier>();

            foreach (string entityUrl in result.People)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.People, GetPeopleIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Films)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Film, GetFilmIdFromUrl(entityUrl)));
            }

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

            foreach (var item in result.Results)
            {
                item.EntityId = GetPlanetIdFromUrl(item.Url);
            }
            return result;
        }

        public async Task<PlanetModel> GetPlanets(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            string url = $"planets/{id}";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<PlanetModel>(content, _serializationOptions);
            result.EntityId = id;
            result.RelatedEntities = new List<EntityIdentifier>();

            foreach (string entityUrl in result.Residents)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.People, GetPeopleIdFromUrl(entityUrl)));
            }
            foreach (string entityUrl in result.Films)
            {
                result.RelatedEntities.Add(new EntityIdentifier(EntityType.Film, GetFilmIdFromUrl(entityUrl)));
            }

            return result;
        }


        private string GetIdFromUrl(string url, string prefix)
        {
            var suffix = url.Substring(url.LastIndexOf(prefix) + prefix.Length);
            return suffix.Substring(0, suffix.Length - 1);
        }

        private string GetFilmIdFromUrl(string url) => GetIdFromUrl(url, "films/");
        private string GetPlanetIdFromUrl(string url) => GetIdFromUrl(url, "planets/");
        private string GetSpeciesIdFromUrl(string url) => GetIdFromUrl(url, "species/");
        private string GetStarshipsIdFromUrl(string url) => GetIdFromUrl(url, "starships/");
        private string GetPeopleIdFromUrl(string url) => GetIdFromUrl(url, "people/");
        private string GetVehiclesIdFromUrl(string url) => GetIdFromUrl(url, "vehicles/");
    }
}
