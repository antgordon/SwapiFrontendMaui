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
    public class SpeciesViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _name;
        private string _classification { get; set; }
        private string _designation { get; set; }
        private double? _averageHeight { get; set; }
        private double? _averageLifespan { get; set; }
        private string _eyeColors { get; set; }
        private string _hairColors { get; set; }
        private string _skinColors { get; set; }
        private string _language { get; set; }
        private string _homeworld { get; set; }

        public SpeciesViewModel()
        {
        }
         
        public SpeciesViewModel(SpeciesModel model)
        {
            EntityId = model.EntityId;
            Name = model.Name;
            Classification = model.Classification;
            Designation = model.Designation;
            AverageHeight = model.Average_Height;
            AverageLifespan = model.Average_Lifespan;
            EyeColors = model.Eye_Colors;
            HairColors = model.Hair_colors;
            SkinColors = model.Skin_Colors;
            Language = model.Language;
            Homeworld = model.Homeworld;

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

        public string Classification
        {
            get => _classification;
            set
            {
                if (_classification != value)
                {
                    _classification = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Designation
        {
            get => _designation;
            set
            {
                if (_designation != value)
                {
                    _designation = value;
                    OnPropertyChanged();
                }
            }
        }
        public double? AverageHeight
        {
            get => _averageHeight;
            set
            {
                if (_averageHeight != value)
                {
                    _averageHeight = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(AverageHeightText));
                }
            }
        }
        public double? AverageLifespan
        {
            get => _averageLifespan;
            set
            {
                if (_averageLifespan != value)
                {
                    _averageLifespan = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(AverageLifespanText));
                }
            }
        }


        public string EyeColors
        {
            get => _eyeColors;
            set
            {
                if (_eyeColors != value)
                {
                    _eyeColors = value;
                    OnPropertyChanged();
                }
            }
        }
        public string HairColors
        {
            get => _hairColors;
            set
            {
                if (_hairColors != value)
                {
                    _hairColors = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SkinColors
        {
            get => _skinColors;
            set
            {
                if (_skinColors != value)
                {
                    _skinColors = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Language
        {
            get => _language;
            set
            {
                if (_language != value)
                {
                    _language = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Homeworld
        {
            get => _homeworld;
            set
            {
                if (_homeworld != value)
                {
                    _homeworld = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EntityId { get; set; }

        public string AverageHeightText { get => AverageHeight.HasValue ? $"{AverageHeight:N1}" : "Unknown"; }
        public string AverageLifespanText { get => AverageLifespan.HasValue ? $"{AverageLifespan:N1}" : "Unknown"; }
    }
}
