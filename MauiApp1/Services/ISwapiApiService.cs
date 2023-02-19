using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface ISwapiApiService
    {

        public Task<FilmSearchModel?> SearchFilms(string query, int page = 1);

        public Task<FilmModel?> GetFilm(string id);

        public Task<VehiclesSeachModel?> SearchVehicles(string query, int page = 1);

        public Task<VehiclesModel?> GetVehicle(string id);

        public Task<PeopleSearchModel?> SearchPeople(string query, int page = 1);

        public Task<PeopleModel?> GetPeople(string id);

        public Task<StarshipsSearchModel> SearchStarship(string query, int page = 1);

        public Task<StarshipModel?> GetStarship(string id);

        public Task<SpeciesSearchModel?> SearchSpecies(string query, int page = 1);

        public Task<SpeciesModel?> GetSpecies(string id);

        public Task<PlanetSearchModel?> SearchPlanets(string query, int page = 1);

        public Task<PlanetModel?> GetPlanets(string id);
    }
}
