using MauiApp1.Services;
using MauiApp1.ViewModel.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace MauiApp1.View.Entity;

public partial class FilmPage : ContentPage, IQueryAttributable
{
    public FilmViewModel ViewModel { get; private set; }

    public string FilmId { get; private set; }

    private ISwapiApiService _swapiApiService;

    public FilmPage()
    {
        _swapiApiService = App.SwapiApiService;

        InitializeComponent();
        ViewModel = new FilmViewModel()
        {
            Title = "Last Jedi",
            ReleaseDate = new DateTime(2020, 6, 1).ToShortDateString(),
            Director = "Director2222",
            Producer = "Producer111",
            OpeningCrawl = "Open ----Crawl"
        };
       
        BindingContext = ViewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        FilmId = query["Id"] as string;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        IsBusy = true;
        var film = await _swapiApiService.GetFilm(FilmId);
        ViewModel = new FilmViewModel(film);
        BindingContext = ViewModel;
        IsBusy = false;

        var charactersTasks = film.RelatedEntities
            .Where(entity => entity.EntityType == Models.Enums.EntityType.People)
            .Select(entity => (entity, _swapiApiService.GetPeople(entity.EntityId)))
            .Select(p => p.Item2.ContinueWith(pv => new FilmViewModel.LinkedEntityViewModel(p.entity, p.Item2.Result.Name, "")))
            .ToList();

        var starshipsTasks = film.RelatedEntities
            .Where(entity => entity.EntityType == Models.Enums.EntityType.Starship)
            .Select(entity => (entity, _swapiApiService.GetStarship(entity.EntityId)))
            .Select(p => p.Item2.ContinueWith(pv => new FilmViewModel.LinkedEntityViewModel(p.entity, p.Item2.Result.Name, "")))
            .ToList();

        var vehiclesTasks = film.RelatedEntities
            .Where(entity => entity.EntityType == Models.Enums.EntityType.Vehicle)
            .Select(entity => (entity, _swapiApiService.GetVehicle(entity.EntityId)))
            .Select(p => p.Item2.ContinueWith(pv => new FilmViewModel.LinkedEntityViewModel(p.entity, p.Item2.Result.Name, "")))
            .ToList();

        var speciesTasks = film.RelatedEntities
            .Where(entity => entity.EntityType == Models.Enums.EntityType.Species)
            .Select(entity => (entity, _swapiApiService.GetSpecies(entity.EntityId)))
            .Select(p => p.Item2.ContinueWith(pv => new FilmViewModel.LinkedEntityViewModel(p.entity, p.Item2.Result.Name, "")))
            .ToList();

        await Task.WhenAll(charactersTasks);
        await Task.WhenAll(starshipsTasks);
        await Task.WhenAll(vehiclesTasks);
        await Task.WhenAll(speciesTasks);
        charactersTasks.ForEach(task => ViewModel.Characters.Add(task.Result));
        starshipsTasks.ForEach(task => ViewModel.Starships.Add(task.Result));
        vehiclesTasks.ForEach(task => ViewModel.Vehicles.Add(task.Result));
        speciesTasks.ForEach(task => ViewModel.Species.Add(task.Result));

    }

    public async void OnTappedViewModel(object sender, EventArgs args)
    {
        var model = (FilmViewModel.LinkedEntityViewModel)((BindableObject)sender).BindingContext;
        await Shell.Current.GoToAsync(model.EntityUrl);
    }


    async void BackOut(object sender, EventArgs args) {
        await Shell.Current.GoToAsync($"//Films");
    }
}