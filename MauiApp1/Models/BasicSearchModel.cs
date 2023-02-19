using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class BasicSearchModel<T>
    {

        public int Count {get; set;}
        public string? Next { get; set; }
        public string? Previous { get; set; }
        public IList<T> Results { get; set; }

    }
}
