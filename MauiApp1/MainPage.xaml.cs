namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		//this.BackgroundColor = Color.FromRgb(0.0, 0.0, 0.0);
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private async void OnNavigateClicked(object sender, EventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
		{
			{ "QueryText", "From main page" }
		};
        await Shell.Current.GoToAsync($"//AboutBinding", navigationParameter);
    }
}

