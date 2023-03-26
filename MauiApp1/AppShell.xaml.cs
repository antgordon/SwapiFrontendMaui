using MauiApp1.View;
using MauiApp1.View.Entity;

namespace MauiApp1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("FilmEntity", typeof(FilmPage));
        Routing.RegisterRoute("SpeciesEntity", typeof(SpeciesPage));
        Routing.RegisterRoute("PeopleEntity", typeof(PeoplePage));
        Routing.RegisterRoute("PlanetEntity", typeof(PlanetPage));
        Routing.RegisterRoute("StarshipsEntity", typeof(StarshipPage));
        Routing.RegisterRoute("VehiclesEntity", typeof(VehiclePage));

        //this.BackgroundColor = Color.FromRgb(255, 255, 0);
    }
}
