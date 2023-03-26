using MauiApp1.Services;
using MauiApp1.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Input;

namespace MauiApp1.ViewModel;

public class FilmSearchViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private string _searchQuery;
    private ObservableCollection<FilmViewModel> _results;
    private int _page = 1;
    private bool _hasNextPage;
    private bool _hasPreviousPage;
    private ISwapiApiService _service;

    public FilmSearchViewModel(ISwapiApiService service)
    {
        _results = new ObservableCollection<FilmViewModel>();
        _service = service;
        SearchCommand = new Command(

            execute: async () =>
            {
                await LoanDataAsync();
                RefreshCanExecutes();
                
            },
            canExecute: () =>
            {
                return true;
            }
        );
        NextPageCommand = new Command(

           execute: async () =>
           {
               Page += 1;
          
               await LoanDataAsync();
               RefreshCanExecutes();
           },
           canExecute: () =>
           {
               return (HasErrorState && Page < 1) || (!HasErrorState && HasNextPage);
           }
        );
        PreviousPageCommand = new Command(

           execute: async () =>
           {
               Page -= 1;

               await LoanDataAsync();
               RefreshCanExecutes();
           },
           canExecute: () =>
           {
               return (HasErrorState && Page > 1) || (!HasErrorState && HasPreviousPage);
           }
        );
    }


    public async Task InitializeAsync()
    {

        await LoanDataAsync();
    }

    public async Task LoanDataAsync()
    {
        try
        {
            var results = await _service.SearchFilms(SearchQuery, Page);
            ClearErrorState();
            this.Results.Clear();
            foreach (var item in results.Results)
            {

                this.Results.Add(new FilmViewModel(item));
            }

            //HasPreviousPage = results.Previous != null;
            //HasNextPage = results.Next != null;
            HasNextPage = true;
            HasPreviousPage = true;
            OnPropertyChanged(nameof(HasPreviousPage));
            OnPropertyChanged(nameof(HasNextPage));
        } 
        catch(Exception ex)
        {
            SetErrorState(ex.Message);
        }
    }


    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            if (_searchQuery != value)
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<FilmViewModel> Results
    {
        get => _results;
        set
        {
            if (_results != value)
            {
                _results = value;
                Count = _results.Count;
                OnPropertyChanged(nameof(Results));
                OnPropertyChanged(nameof(Count));
            }
        }
    }

    public int Count { get; private set; }

    public int Page
    {
        get => _page;
        set
        {
            if (_page != value)
            {
                _page = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PageNumberText));
            }
        }
    }

    public string PageNumberText { get => $"Page {Page}"; }

    public bool HasNextPage
    {
        get => _hasNextPage;
        set
        {
            if (_hasNextPage != value)
            {
                _hasNextPage = value;
                RefreshCanExecutes();
                OnPropertyChanged();
            }
        }
    }

    public bool HasPreviousPage
    {
        get => _hasPreviousPage;
        set
        {
            if (_hasPreviousPage != value)
            {
                _hasPreviousPage = value;
                RefreshCanExecutes();
                OnPropertyChanged();
            }
        }
    }

    public bool HasErrorState { get; private set; }
    public string ErrorStateMessage { get; private set; }
    public bool IsRenderingErrorState { get => HasErrorState; }
    public bool IsRenderingNormalState { get => !HasErrorState; }

    public ICommand SearchCommand { private set; get; }

    public ICommand PreviousPageCommand { private set; get; }

    public ICommand NextPageCommand { private set; get; }

    public void SetErrorState(string errorMessage)
    {
        HasErrorState = true;
        ErrorStateMessage = errorMessage;
        OnPropertyChanged(nameof(HasErrorState));
        OnPropertyChanged(nameof(IsRenderingErrorState));
        OnPropertyChanged(nameof(IsRenderingNormalState));
        OnPropertyChanged(nameof(ErrorStateMessage));
    }

    public void ClearErrorState()
    {
        HasErrorState = false;
        ErrorStateMessage = "";
        OnPropertyChanged(nameof(HasErrorState));
        OnPropertyChanged(nameof(IsRenderingErrorState));
        OnPropertyChanged(nameof(IsRenderingNormalState));
        OnPropertyChanged(nameof(ErrorStateMessage));
    }

    void RefreshCanExecutes()
    {
        (SearchCommand as Command).ChangeCanExecute();
        (PreviousPageCommand as Command).ChangeCanExecute();
        (NextPageCommand as Command).ChangeCanExecute();
    }
}

