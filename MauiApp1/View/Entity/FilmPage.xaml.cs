using MauiApp1.Services;
using MauiApp1.ViewModel.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
    }


    async void BackOut(object sender, EventArgs args) {
        await Shell.Current.GoToAsync($"//Films");
    }
}