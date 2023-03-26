using MauiApp1.ViewModel;
using MauiApp1.ViewModel.Entity;

namespace MauiApp1.View;

public partial class StarshipsSearchPage : ContentPage
{
    public StarshipSearchViewModel ViewModel { get; private set; }

    public StarshipsSearchPage()
    {
        ViewModel = new StarshipSearchViewModel(App.SwapiApiService);
        BindingContext = ViewModel;
        InitializeComponent();

        SearchContent.ItemTapped += OnTapped;
    }

    public async void OnTapped(object sender, EventArgs args)
    {
        var model = (StarshipViewModel)((BindableObject)sender).BindingContext;
        ViewModel.OpenItemCommand.Execute($"StarshipsEntity?Id={model.EntityId}");
    }
}