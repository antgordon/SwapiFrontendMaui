using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class PlanetSearchViewModel : AbstractSearchViewModel<PlanetSearchModel, PlanetModel,PlanetViewModel>
    {
        public PlanetSearchViewModel(ISwapiApiService service) : base(service)
        {
            Title = "Planet Page";
            SearchPlaceHolder = "Search For Planets";
        }

        protected override Task<IEnumerable<PlanetViewModel>> GetElementModels(PlanetSearchModel searchModel)
        {
            return Task.FromResult(searchModel.Results.Select(item => new PlanetViewModel(item)));
        }

        protected override async Task<PlanetSearchModel?> GetSearchModel(ISwapiApiService swapiApiService, string searchQuery, int page)
        {
            return await swapiApiService.SearchPlanets(searchQuery, page);
        }
    }
}
