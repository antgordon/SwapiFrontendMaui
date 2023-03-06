using MauiApp1.ViewModel;

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
        var model = ((PeopleViewModel)((VerticalStackLayout)sender).BindingContext);
        ViewModel.OpenItemCommand.Execute($"People?PeopleId={model.EntityId}");
    }
}