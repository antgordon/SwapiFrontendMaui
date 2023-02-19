using MauiApp1.Services;

namespace MauiApp1;

public partial class App : Application
{

	public static ISwapiApiService SwapiApiService { get; private set; }

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		SwapiApiService = new SwapiApiService();
        //Application.Current.UserAppTheme = AppTheme.Dark;
    }
}
