using MauiApp1.Models;
using MauiApp1.ViewModel;
using MauiApp1.ViewModel.Entity;

namespace MauiApp1.View;

public partial class VehiclesSearchPage : ContentPage
{
    public VehiclesSearchViewModel ViewModel { get; private set; }

    public VehiclesSearchPage()
    {
        ViewModel = new VehiclesSearchViewModel(App.SwapiApiService);
        BindingContext = ViewModel;
        InitializeComponent();

        SearchContent.ItemTapped += OnTapped;
    }

    public async void OnTapped(object sender, EventArgs args)
    {
        var model = (VehicleViewModel)((BindableObject)sender).BindingContext;
        ViewModel.OpenItemCommand.Execute($"VehiclesEntity?Id={model.EntityId}");
    }
}