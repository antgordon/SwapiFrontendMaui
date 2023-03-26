using MauiApp1.ViewModel.Entity;
using MauiApp1.Services;


namespace MauiApp1.View.Entity;

public partial class PlanetPage : ContentPage, IQueryAttributable
{

    public PlanetViewModel ViewModel { get; private set; }

    public string EntityId { get; private set; }

    private ISwapiApiService _swapiApiService;

    public PlanetPage()
    {
        _swapiApiService = App.SwapiApiService;
        InitializeComponent();
        ViewModel = new PlanetViewModel()
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
        var people = await _swapiApiService.GetPlanets(EntityId);
        ViewModel = new PlanetViewModel(people);
        BindingContext = ViewModel;
        IsBusy = false;
    }


    async void BackOut(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"//Planets");
    }
}