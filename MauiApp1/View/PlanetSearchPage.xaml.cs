using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class PlanetSearchPage : ContentPage
{

    public PlanetSearchViewModel ViewModel { get; private set; }

    public PlanetSearchPage()
	{
        ViewModel = new PlanetSearchViewModel(App.SwapiApiService);
        BindingContext = ViewModel;
        InitializeComponent();

        SearchContent.ItemTapped += OnTapped;
	}

    public async void OnTapped(object sender, EventArgs args)
    {
        var model = ((PeopleViewModel)((VerticalStackLayout)sender).BindingContext);
        ViewModel.OpenItemCommand.Execute($"People?PeopleId={model.EntityId}");

    }
}