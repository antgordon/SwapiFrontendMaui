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
    public class PeopleSearchViewModel : AbstractSearchViewModel<PeopleSearchModel, PeopleModel, PeopleViewModel>
    {
        public PeopleSearchViewModel(ISwapiApiService service) : base(service)
        {
            Title = "People Page";
            SearchPlaceHolder = "Search For People";
        }

        protected override Task<IEnumerable<PeopleViewModel>> GetElementModels(PeopleSearchModel searchModel)
        {
            return Task.FromResult(searchModel.Results.Select(item => new PeopleViewModel(item)));
        }

        protected override async Task<PeopleSearchModel?> GetSearchModel(ISwapiApiService swapiApiService, string searchQuery, int page)
        {
            return await swapiApiService.SearchPeople(searchQuery, page);
        }
    }
}
