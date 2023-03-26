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
    public class PeopleViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _name;

        private string _height;

        private string _mass;

        private string _hairColor;

        private string _skinColor;
        private string _eyeColor;

        private string _birthYear;

        private string _gender;

        public PeopleViewModel()
        {

        }

        public PeopleViewModel(PeopleModel model)
        {
            EntityId = model.EntityId;
            Name = model.Name;
            Mass = model.Mass.HasValue ? $"{model.Mass:N1}" : "Unknown";
            Height = model.Height.HasValue ? $"{model.Height:N1}" : "Unknown";
            HairColor = model.Hair_Color;
            SkinColor = model.Skin_Color;
            EyeColor = model.Eye_Color;
            Gender = model.Gender;
            BirthYear = model.Birth_Year;
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


        public string Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Mass
        {
            get => _mass;
            set
            {
                if (_mass != value)
                {
                    _mass = value;
                    OnPropertyChanged();
                }
            }
        }

        public string HairColor
        {
            get => _hairColor;
            set
            {
                if (_hairColor != value)
                {
                    _hairColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SkinColor
        {
            get => _skinColor;
            set
            {
                if (_skinColor != value)
                {
                    _skinColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EyeColor
        {
            get => _eyeColor;
            set
            {
                if (_eyeColor != value)
                {
                    _eyeColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string BirthYear
        {
            get => _birthYear;
            set
            {
                if (_birthYear != value)
                {
                    _birthYear = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }

        //Relationship
        public string Homeworld { get; set; }

        //Relationship
        public IList<string> Films { get; set; }

        //Relationship
        public IList<string> Species { get; set; }

        //Relationship
        public IList<string> Vehicles { get; set; }

        //Relationship
        public IList<string> Starships { get; set; }

        public string EntityId { get; set; }
    }
}
