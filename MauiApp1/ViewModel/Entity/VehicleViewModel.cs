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
    public class VehicleViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _name;

        private string _model { get; set; }
        private string _vehicleClass { get; set; }
        private string _manufacturer { get; set; }
        private string _length { get; set; }
        private string _cost { get; set; }
        private string _crew { get; set; }
        private string _passengers { get; set; }
        private string _maxAtmospheringSpeed { get; set; }
        private string _cargoCapacity { get; set; }
        private string _consumables { get; set; }

        public VehicleViewModel()
        {

        }

        public VehicleViewModel(VehicleModel model)
        {
            EntityId = model.EntityId;
            Name = model.Name;
            Model = model.Model;
            VehicleClass = model.Vehicle_Class;
            Manufacturer = model.Manufacturer;
            Length = model.Length.HasValue ? $"{model.Length:N1}" : "Unknown";
            Cost = model.Cost_In_Credits.HasValue ? $"{model.Cost_In_Credits:N1}" : "Unknown";
            Crew = model.Crew.HasValue ? $"{model.Crew:N1}" : "Unknown";
            Passengers = model.Passengers.HasValue ? $"{model.Passengers:N1}" : "Unknown";
            MaxAtmospheringSpeed = model.Max_Atmosphering_Speed.HasValue ? $"{model.Max_Atmosphering_Speed:N1}" : "Unknown";
            CargoCapacity = model.Cargo_Capacity.HasValue ? $"{model.Cargo_Capacity:N1}" : "Unknown";
            Consumables = model.Consumables;

        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
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

        public string VehicleClass
        {
            get => _vehicleClass;
            set
            {
                if (_vehicleClass != value)
                {
                    _vehicleClass = value;
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

        public IList<string> Pilots { get; set; }
        public IList<string> Films { get; set; }


        public string EntityId { get; set; }
    }
}
