using MauiApp1.ViewModel;
using MauiApp1.ViewModel.Entity;

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
        var model = (PlanetViewModel)((BindableObject)sender).BindingContext;
        ViewModel.OpenItemCommand.Execute($"PlanetEntity?Id={model.EntityId}");
    }
}