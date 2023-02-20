using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class PeopleViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _name;

        public PeopleViewModel() 
        { 
        
        }

        public PeopleViewModel(PeopleModel model) 
        {
            var suffix = model.Url.Substring(model.Url.LastIndexOf("people/") + "people/".Length);
            EntityId = suffix.Substring(0, suffix.Length - 1);
            Name = model.Name;

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
        public string EntityId { get; set; }
    }
}
