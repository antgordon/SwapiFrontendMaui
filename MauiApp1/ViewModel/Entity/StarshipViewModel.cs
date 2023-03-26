using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel.Entity
{
    public class StarshipViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _name;
        private string _model { get; set; }
        private string _manufacturer { get; set; }
        private string _cost { get; set; }
        private string _length { get; set; }
        private string _maxAtmospheringSpeed { get; set; }
        private string _crew { get; set; }
        private string _passengers { get; set; }
        private string _cargoCapacity { get; set; }
        private string _consumables { get; set; }
        private string _hyperdriveRating { get; set; }
        private string _MGLT { get; set; }
        private string _starshipClass { get; set; }

        public StarshipViewModel() 
        { 
        
        }

        public StarshipViewModel(StarshipModel model) 
        {
            EntityId = model.EntityId;
            Name = model.Name;
            Model = model.Model;
            Manufacturer = model.Manufacturer;
            Cost = model.Cost_In_Credits;
            Length = model.Length;
            MaxAtmospheringSpeed = model.Max_Atmosphering_Speed;
            Crew = model.Crew;
            Passengers = model.Passengers;
            CargoCapacity = model.Cargo_Capcity;
            Consumables = model.Consumables;
            HyperdriveRating = model.Hyperdrive_Rating;
            MGLT = model.MGLT;
            StarshipClass = model.Starship_Class;
        }

        public string Name 
        {
            get => _name;
            set
            {
                if (_name != value) {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Manufacturer
        {
            get => _manufacturer;
            set
            {
                if (_manufacturer != value)
                {
                    _manufacturer = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Cost
        {
            get => _cost;
            set
            {
                if (_cost != value)
                {
                    _cost = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Length
        {
            get => _length;
            set
            {
                if (_length != value)
                {
                    _length = value;
                    OnPropertyChanged();
                }
            }
        }

        public string MaxAtmospheringSpeed
        {
            get => _maxAtmospheringSpeed;
            set
            {
                if (_maxAtmospheringSpeed != value)
                {
                    _maxAtmospheringSpeed = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Crew
        {
            get => _crew;
            set
            {
                if (_crew != value)
                {
                    _crew = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Passengers
        {
            get => _passengers;
            set
            {
                if (_passengers != value)
                {
                    _passengers = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CargoCapacity
        {
            get => _cargoCapacity;
            set
            {
                if (_cargoCapacity != value)
                {
                    _cargoCapacity = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Consumables
        {
            get => _consumables;
            set
            {
                if (_consumables != value)
                {
                    _consumables = value;
                    OnPropertyChanged();
                }
            }
        }

        public string HyperdriveRating
        {
            get => _hyperdriveRating;
            set
            {
                if (_hyperdriveRating != value)
                {
                    _hyperdriveRating = value;
                    OnPropertyChanged();
                }
            }
        }

        public string MGLT
        {
            get => _MGLT;
            set
            {
                if (_MGLT != value)
                {
                    _MGLT = value;
                    OnPropertyChanged();
                }
            }
        }

        public string StarshipClass
        {
            get => _starshipClass;
            set
            {
                if (_starshipClass != value)
                {
                    _starshipClass = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<string> Pilots { get; set; }
        public IList<string> Films { get; set; }

        public string EntityId { get; set; }
    }
}
