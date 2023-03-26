using MauiApp1.ViewModel.Entity;
using MauiApp1.Services;

namespace MauiApp1.View.Entity;

public partial class StarshipPage : ContentPage, IQueryAttributable
{
    public StarshipViewModel ViewModel { get; private set; }

    public string EntityId { get; private set; }

    private ISwapiApiService _swapiApiService;

    public StarshipPage()
    {
        _swapiApiService = App.SwapiApiService;
        InitializeComponent();
        ViewModel = new StarshipViewModel()
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
        var starshipModel = await _swapiApiService.GetStarship(EntityId);
        ViewModel = new StarshipViewModel(starshipModel);
        BindingContext = ViewModel;
        IsBusy = false;
    }


    async void BackOut(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"//Starships");
    }
}