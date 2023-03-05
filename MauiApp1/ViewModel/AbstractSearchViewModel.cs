using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModel;

public abstract class AbstractSearchViewModel<S,T,V> : INotifyPropertyChanged
    where S : BasicSearchModel<T>
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private string _searchQuery;
    private Guid _taskGuid;
    private bool _loadingResults;
    private ObservableCollection<V> _results;
    private int _page = 1;
    private bool _hasNextPage;
    private bool _hasPreviousPage;
    private ISwapiApiService _service;
    private string _title;
    private string _searchPlaceHolder;

    public AbstractSearchViewModel(ISwapiApiService service)
    {
        _results = new ObservableCollection<V>();
        _service = service;
        SearchCommand = new Command(

            execute: async () =>
            {
                this.Results.Clear();
                LoanDataAsync();
                RefreshCanExecutes();
                
            },
            canExecute: () =>
            {
                return true;
            }
        );
        NextPageCommand = new Command(

           execute:  () =>
           {
               Page += 1;
          
               LoanDataAsync();
               RefreshCanExecutes();
           },
           canExecute: () =>
           {
               return (HasErrorState && Page < 1) || (!HasErrorState && HasNextPage);
           }
        );
        PreviousPageCommand = new Command(

           execute: () =>
           {
               Page -= 1;

               LoanDataAsync();
            
           },
           canExecute: () =>
           {
               return (HasErrorState && Page > 1) || (!HasErrorState && HasPreviousPage);
           }
        );

        OpenItemCommand = new Command<string>( async (string path) => 
        {
            await Shell.Current.GoToAsync(path);
        });
    }


    public async Task InitializeAsync()
    {

        LoanDataAsync();
    }

    public void LoanDataAsync()
    {
        var searchTask = GetSearchModel(_service, SearchQuery, Page);
        _taskGuid = Guid.NewGuid();
        _loadingResults = true;
        OnPropertyChanged(nameof(IsLoadingResults));

        var taskId = _taskGuid;

        searchTask.ContinueWith(async task =>
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                return ProcessSeachResults(taskId, task);
            });
        });
    }


    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }

    public string SearchPlaceHolder
    {
        get => _searchPlaceHolder;
        set
        {
            if (_searchPlaceHolder != value)
            {
                _searchPlaceHolder = value;
                OnPropertyChanged();
            }
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

    public ObservableCollection<V> Results
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
    public bool IsRenderingErrorState { get => HasErrorState && !IsLoadingResults; }
    public bool IsRenderingNormalState { get => !HasErrorState && !IsLoadingResults; }

    public ICommand SearchCommand { private set; get; }

    public ICommand PreviousPageCommand { private set; get; }

    public ICommand NextPageCommand { private set; get; }

    public ICommand OpenItemCommand { private set; get; }

    public bool IsLoadingResults { get => _loadingResults; }

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

    private async Task ProcessSeachResults(Guid taskGuid, Task<S> searchResultTask)
    {
        if (_taskGuid == taskGuid)
        {
            try
            {
                var searchResult = searchResultTask.Result;
                this.Results.Clear();
                _loadingResults = false;
                OnPropertyChanged(nameof(IsLoadingResults));
                ClearErrorState();
                var models = await GetElementModels(searchResult);
                foreach (var model in models)
                {
                    this.Results.Add(model);
                }

                HasPreviousPage = searchResult.Previous != null;
                HasNextPage = searchResult.Next != null;
                OnPropertyChanged(nameof(HasPreviousPage));
                OnPropertyChanged(nameof(HasNextPage));
                RefreshCanExecutes();
            }
            catch (Exception ex)
            {
                _loadingResults = false;
                OnPropertyChanged(nameof(IsLoadingResults));
                SetErrorState(ex.Message);
            }
        }
    }

    protected abstract Task<S> GetSearchModel(ISwapiApiService swapiApiService, string searchQuery, int page);

    protected abstract Task<IEnumerable<V>> GetElementModels(S searchModel);
}

