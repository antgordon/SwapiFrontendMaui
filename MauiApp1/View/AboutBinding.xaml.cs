using MauiApp1.Models;

namespace MauiApp1.View;

[QueryProperty(nameof(QueryText), "QueryText")]
public partial class AboutBinding : ContentPage
{
    private string _queryText;
    public string QueryText
    {
        get => _queryText;
        set
        {
            _queryText = value;
            OnPropertyChanged();
        }
    }

    public AboutBinding()
    {
        if (QueryText == null) {
            QueryText = "Default";
        }

        InitializeComponent();
        var binding = new AboutBinidngModel();
        binding.Text = "Here is noise";
        BindingContext = binding;
        label.BindingContext = slider;
        label.SetBinding(Label.RotationProperty, "Value");

    }
}