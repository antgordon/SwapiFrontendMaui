using MauiApp1.View;

namespace MauiApp1;

public partial class AppShell : Shell
{
    public AppShell()
    {

        InitializeComponent();
        Routing.RegisterRoute("Film", typeof(FilmPage));
        //this.BackgroundColor = Color.FromRgb(255, 255, 0);
    }
}
