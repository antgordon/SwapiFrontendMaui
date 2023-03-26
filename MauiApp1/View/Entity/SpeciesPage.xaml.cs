using MauiApp1.Services;
using MauiApp1.ViewModel.Entity;

namespace MauiApp1.View.Entity;

public partial class SpeciesPage : ContentPage, IQueryAttributable
{
    public SpeciesViewModel ViewModel { get; private set; }

    public string EntityId { get; private set; }

    private ISwapiApiService _swapiApiService;

    public SpeciesPage()
	{
        _swapiApiService = App.SwapiApiService;
        InitializeComponent();
        ViewModel = new SpeciesViewModel()
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
        var id = EntityId;
        IsBusy = true;
        var species = await _swapiApiService.GetSpecies(EntityId);
        ViewModel = new SpeciesViewModel(species);
        BindingContext = ViewModel;
        IsBusy = false;
    }


    async void BackOut(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"//Species");
    }
}