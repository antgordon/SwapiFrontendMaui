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
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public long Cost_In_Credits { get; set; }
        public int Length { get; set; }
        public string Max_Atmosphering_Speed { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public long Cargo_Capcity { get; set; }
        public string Consumables { get; set; }
        public double Hyperdrive_Rating { get; set; }
        public int MGLT { get; set; }
        public string Starship_Class { get; set; }
        public IList<string> Pilots { get; set; }
        public IList<string> Films {get; set;}
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
        public string EntityId { get; set;}
    }
}
