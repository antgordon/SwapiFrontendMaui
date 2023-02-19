using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1.View;

public partial class FilmsPage : ContentPage
{

	public FilmSearchViewModel ViewModel { get; private set; }
	public FilmsPage()
	{
		InitializeComponent();
		ViewModel = new FilmSearchViewModel(App.SwapiApiService);
		BindingContext = ViewModel;
    }


    public async void OnTapped(object sender, EventArgs args) {
		var model = ((FilmViewModel)((VerticalStackLayout)sender).BindingContext);
         await Shell.Current.GoToAsync($"Film?FilmId={model.EntityId}");
	}
}