using MauiApp1.ViewModel.Entity;
using MauiApp1.Services;

namespace MauiApp1.View.Entity;

public partial class VehiclePage : ContentPage, IQueryAttributable
{
    public VehicleViewModel ViewModel { get; private set; }

    public string EntityId { get; private set; }

    private ISwapiApiService _swapiApiService;

    public VehiclePage()
    {
        _swapiApiService = App.SwapiApiService;
        InitializeComponent();
        ViewModel = new VehicleViewModel()
        {
            Name = "Loading"
        };

        BindingContext = ViewModel;

    }


    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        EntityId = query["Id"] as string;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        IsBusy = true;
        var vehicleModel = await _swapiApiService.GetVehicle(EntityId);
        ViewModel = new VehicleViewModel(vehicleModel);
        BindingContext = ViewModel;
        IsBusy = false;
    }


    async void BackOut(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"//Vehicles");
    }
}