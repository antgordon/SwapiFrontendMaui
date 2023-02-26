using System.Windows.Input;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public ICommand NavigationCommand { get; private set; }

    public ICommand TestCommand { get; private set; }

    public MainPage()
    {
        NavigationCommand = new Command<string>(async (string route) =>
        {
            await Shell.Current.GoToAsync(route);
        });

        InitializeComponent();
    }

}

