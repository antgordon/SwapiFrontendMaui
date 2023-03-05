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
    public FilmSearchPageItemView ItemView { get; private set; }

    public FilmsPage()
    {
        InitializeComponent();
        ViewModel = new FilmSearchViewModel(App.SwapiApiService);
        ItemView = new FilmSearchPageItemView();
        BindingContext = ViewModel;
        var def = ResultsContent.ItemTemplate.LoadTemplate;
        ResultsContent.ItemTemplate.LoadTemplate = () => {
            var obj = def();
            AbsoluteLayout layout = (AbsoluteLayout)obj;
            var label = new Label() { Text = "LETTS GOOOO" };
            layout.Children.Add(label);
            return layout;
        };
    }


    public async void OnTapped(object sender, EventArgs args) {
        var model = ((FilmViewModel)((BindableObject)sender).BindingContext);
         await Shell.Current.GoToAsync($"Film?FilmId={model.EntityId}");
    }
}