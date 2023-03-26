using MauiApp1.ViewModel;
using MauiApp1.ViewModel.Entity;
using Microsoft.Maui.Controls;

namespace MauiApp1.View;

public partial class SpeciesSearchPage : ContentPage
{ 
    public SpeciesSearchViewModel ViewModel { get; private set; }

    public SpeciesSearchPage()
    {
        ViewModel = new SpeciesSearchViewModel(App.SwapiApiService);
        BindingContext = ViewModel;
        InitializeComponent();

        SearchContent.ItemTapped += OnTapped;
    }

    public async void OnTapped(object sender, EventArgs args)
    {
        var model = (SpeciesViewModel)((BindableObject)sender).BindingContext;
        ViewModel.OpenItemCommand.Execute($"SpeciesEntity?Id={model.EntityId}");
    }
}