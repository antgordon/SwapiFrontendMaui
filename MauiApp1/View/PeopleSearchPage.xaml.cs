using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.ViewModel;
using MauiApp1.ViewModel.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1.View;

public partial class PeopleSearchPage : ContentPage
{

    public PeopleSearchViewModel ViewModel { get; private set; }

    public PeopleSearchPage()
    {
        ViewModel = new PeopleSearchViewModel(App.SwapiApiService);
        BindingContext = ViewModel;
        InitializeComponent();

    }

    public async void OnTapped(object sender, EventArgs args) {
        var model = (PeopleViewModel)((BindableObject)sender).BindingContext;
        ViewModel.OpenItemCommand.Execute($"PeopleEntity?Id={model.EntityId}");

    }
}