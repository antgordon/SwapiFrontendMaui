using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class StarshipSearchViewModel : AbstractSearchViewModel<StarshipsSearchModel, StarshipModel, StarshipViewModel>
    {
        public StarshipSearchViewModel(ISwapiApiService service) : base(service)
        {
            Title = "Starship Page";
            SearchPlaceHolder = "Search For Starship";
        }

        protected override Task<IEnumerable<StarshipViewModel>> GetElementModels(StarshipsSearchModel searchModel)
        {
            return Task.FromResult(searchModel.Results.Select(item => new StarshipViewModel(item)));
        }

        protected override async Task<StarshipsSearchModel?> GetSearchModel(ISwapiApiService swapiApiService, string searchQuery, int page)
        {
            return await swapiApiService.SearchStarships(searchQuery, page);
        }
    }
}
