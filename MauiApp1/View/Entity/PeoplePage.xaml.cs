using MauiApp1.Services;
using MauiApp1.ViewModel.Entity;

namespace MauiApp1.View.Entity;

public partial class PeoplePage : ContentPage, IQueryAttributable
{
    public PeopleViewModel ViewModel { get; private set; }

    public string EntityId { get; private set; }

    private ISwapiApiService _swapiApiService;

    public PeoplePage()
    {
        _swapiApiService = App.SwapiApiService;
        InitializeComponent();
        ViewModel = new PeopleViewModel()
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
        var people = await _swapiApiService.GetPeople(EntityId);
        ViewModel = new PeopleViewModel(people);
        BindingContext = ViewModel;
        IsBusy = false;
    }


    async void BackOut(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"//People");
    }
}