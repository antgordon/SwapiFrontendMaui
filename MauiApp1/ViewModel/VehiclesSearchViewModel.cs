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
    public class VehiclesSearchViewModel : AbstractSearchViewModel<VehiclesSearchModel, VehicleModel, VehicleViewModel>
    {
        public VehiclesSearchViewModel(ISwapiApiService service) : base(service)
        {
            Title = "Vehicles Page";
            SearchPlaceHolder = "Search For Vehicles";
        }

        protected override Task<IEnumerable<VehicleViewModel>> GetElementModels(VehiclesSearchModel searchModel)
        {
            return Task.FromResult(searchModel.Results.Select(item => new VehicleViewModel(item)));
        }

        protected override async Task<VehiclesSearchModel?> GetSearchModel(ISwapiApiService swapiApiService, string searchQuery, int page)
        {
            return await swapiApiService.SearchVehicles(searchQuery, page);
        }
    }
}
