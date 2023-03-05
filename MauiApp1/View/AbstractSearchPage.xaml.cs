using MauiApp1.Models;
using MauiApp1.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.View;

public partial class AbstractSearchPage : ContentView
{
    public event EventHandler<EventArgs> ItemTapped;

    private DataTemplate _itemTemplate;
    public event PropertyChangedEventHandler PropertyChanged;

    public AbstractSearchPage()
    {
        InitializeComponent();
        var def = ResultsContent.ItemTemplate.LoadTemplate;
        ResultsContent.ItemTemplate.LoadTemplate = () => {
            var obj = def();
            AbsoluteLayout layout = (AbsoluteLayout)obj;
            if (ItemTemplate != null)
            {
                layout.Children.Add((IView)ItemTemplate.LoadTemplate());
            }
            return layout;
        };
    }


    public async void OnTapped(object sender, EventArgs args)
    {
        ItemTapped?.Invoke(sender, args);

    }

    public DataTemplate ItemTemplate
    {
        get => _itemTemplate;
        set
        {
            if (_itemTemplate != value)
            {
                _itemTemplate = value;
                OnPropertyChanged();
            }
        }
    }

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

}