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
    public class PlanetViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _name;
        private string _rotationPeriod { get; set; }
        private string _orbitalPeriod { get; set; }
        private string _diameter { get; set; }
        private string _climate { get; set; }
        private string _gravity { get; set; }
        private string _terrain { get; set; }
        private string _surfaceWater { get; set; }
        private string _population { get; set; }

        public PlanetViewModel()
        {

        }

        public PlanetViewModel(PlanetModel model)
        {
            EntityId = model.EntityId;
            Name = model.Name;
            RotationPeriod = model.Rotation_Period.ToString();
            OrbitalPeriod = model.Orbital_Period.ToString();
            Diameter = model.Diameter.ToString();
            Climate = model.Climate;
            Gravity = model.Gravity;
            Terrain = model.Terrain;
            SurfaceWater = model.Surface_Water;
            Population = model.Population.HasValue ? $"{model.Population:N1}" : "Unknown";

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

        public string RotationPeriod
        {
            get => _rotationPeriod;
            set
            {
                if (_rotationPeriod != value)
                {
                    _rotationPeriod = value;
                    OnPropertyChanged();
                }
            }
        }

        public string OrbitalPeriod
        {
            get => _orbitalPeriod;
            set
            {
                if (_orbitalPeriod != value)
                {
                    _orbitalPeriod = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Diameter
        {
            get => _diameter;
            set
            {
                if (_diameter != value)
                {
                    _diameter = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Climate
        {
            get => _climate;
            set
            {
                if (_climate != value)
                {
                    _climate = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Gravity
        {
            get => _gravity;
            set
            {
                if (_gravity != value)
                {
                    _gravity = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Terrain
        {
            get => _terrain;
            set
            {
                if (_terrain != value)
                {
                    _terrain = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SurfaceWater
        {
            get => _surfaceWater;
            set
            {
                if (_surfaceWater != value)
                {
                    _surfaceWater = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Population
        {
            get => _population;
            set
            {
                if (_population != value)
                {
                    _population = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<string> Residents { get; set; }
        public IList<string> Films { get; set; }

        public string EntityId { get; set; }

    }
}
