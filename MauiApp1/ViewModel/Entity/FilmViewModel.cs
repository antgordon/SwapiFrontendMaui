using MauiApp1.Models;
using MauiApp1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
        private ObservableCollection<LinkedEntityViewModel> _characters;
        private ObservableCollection<LinkedEntityViewModel> _starships;
        private ObservableCollection<LinkedEntityViewModel> _vehicles;
        private ObservableCollection<LinkedEntityViewModel> _species;

        public FilmViewModel()
        {
        }

        public FilmViewModel(FilmModel model)
        {
            Title = model.Title;
            OpeningCrawl = model.Opening_Crawl;
            Director = model.Director;
            Producer = model.Producer;
            ReleaseDate = model.Release_Date.ToShortDateString();
            EntityId = model.EntityId;
            _characters = new ObservableCollection<LinkedEntityViewModel>();
            _starships = new ObservableCollection<LinkedEntityViewModel>();
            _vehicles = new ObservableCollection<LinkedEntityViewModel>();
            _species = new ObservableCollection<LinkedEntityViewModel>();

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


        public record LinkedEntityViewModel
        { 
            public EntityIdentifier EntityIdentifier { get; }
            public string EntityName { get; }
            public string ReturnUrl { get; }
            public string EntityUrl { get; }

            public LinkedEntityViewModel(EntityIdentifier entityIdentifier, string entityName, string returnUrl)
            {
                EntityIdentifier = entityIdentifier;
                EntityName = entityName;
                EntityUrl = MakeUrl(entityIdentifier);
                ReturnUrl = returnUrl;
            }

            private static string MakeUrl(EntityIdentifier identifier)
            {
                return identifier.EntityType switch
                {
                    EntityType.People=> $"PeopleEntity?Id={identifier.EntityId}",
                    EntityType.Starship => $"StarshipsEntity?Id={identifier.EntityId}",
                    EntityType.Vehicle => $"VehiclesEntity?Id={identifier.EntityId}",
                    EntityType.Species => $"SpeciesEntityId={identifier.EntityId}",
                    EntityType.Film => $"FilmEntity?Id={identifier.EntityId}",
                    EntityType.Planet => $"PlanetEntity?Id={identifier.EntityId}",
                    _ => ""
                };
            }
        }

        public ObservableCollection<LinkedEntityViewModel> Characters
        {
            get => _characters;
            set
            {
                if (_characters != value)
                {
                    _characters = value;
                    OnPropertyChanged(nameof(Characters));
                }
            }
        }

        public ObservableCollection<LinkedEntityViewModel> Starships
        {
            get => _starships;
            set
            {
                if (_starships != value)
                {
                    _starships = value;
                    OnPropertyChanged(nameof(Starships));
                }
            }
        }

        public ObservableCollection<LinkedEntityViewModel> Vehicles
        {
            get => _vehicles;
            set
            {
                if (_vehicles != value)
                {
                    _vehicles = value;
                    OnPropertyChanged(nameof(Vehicles));
                }
            }
        }

        public ObservableCollection<LinkedEntityViewModel> Species
        {
            get => _species;
            set
            {
                if (_species != value)
                {
                    _species = value;
                    OnPropertyChanged(nameof(Species));
                }
            }
        }
    }
}
