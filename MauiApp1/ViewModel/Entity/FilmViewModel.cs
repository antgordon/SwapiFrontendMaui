using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModel.Entity
{
    public class FilmViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _title;
        private string _openingCrawl;
        private string _director;
        private string _producer;
        private string _releaseDate;

        public FilmViewModel()
        {
        }

        public FilmViewModel(FilmModel model)
        {
            var suffix = model.Url.Substring(model.Url.LastIndexOf("films/") + "films/".Length);
            var entityId = suffix.Substring(0, suffix.Length - 1);

            Title = model.Title;
            OpeningCrawl = model.Opening_Crawl;
            Director = model.Director;
            Producer = model.Producer;
            ReleaseDate = model.Release_Date.ToShortDateString();
            EntityId = entityId;
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
        public string OpeningCrawl
        {
            get => _openingCrawl;
            set
            {
                if (_openingCrawl != value)
                {
                    _openingCrawl = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Director
        {
            get => _director;
            set
            {
                if (_director != value)
                {
                    _director = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Producer
        {
            get => _producer;
            set
            {
                if (_producer != value)
                {
                    _producer = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (_releaseDate != value)
                {
                    _releaseDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EntityId { get; set; }
    }
}
