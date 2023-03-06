using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class SpeciesSearchViewModel : AbstractSearchViewModel<SpeciesSearchModel, SpeciesModel, SpeciesViewModel>
    {
        public SpeciesSearchViewModel(ISwapiApiService service) : base(service)
        {
            Title = "Species Page";
            SearchPlaceHolder = "Search For Species";
        }

        protected override Task<IEnumerable<SpeciesViewModel>> GetElementModels(SpeciesSearchModel searchModel)
        {
            return Task.FromResult(searchModel.Results.Select(item => new SpeciesViewModel(item)));
        }

        protected override async Task<SpeciesSearchModel?> GetSearchModel(ISwapiApiService swapiApiService, string searchQuery, int page)
        {
            return await swapiApiService.SearchSpecies(searchQuery, page);
        }
    }
}
