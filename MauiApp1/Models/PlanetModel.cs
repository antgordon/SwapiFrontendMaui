using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class PlanetModel
    {

        public string Name { get; set; }
        public int Rotation_Period { get; set; }
        public int Orbital_Period { get; set; }
        public int Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string Surface_Water { get; set; }
        public int? Population { get; set; }
        public IList<string> Residents { get; set; }
        public IList<string> Films { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
        public string EntityId { get; set; }
    }
}
