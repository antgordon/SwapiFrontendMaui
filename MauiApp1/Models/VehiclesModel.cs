using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class VehiclesModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Vehicle_Class { get; set; }
        public string Manufacturer { get; set; }
        public double Length { get; set; }
        public int Cost_In_Credits { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public int Max_Atmosphering_Speed { get; set; }
        public int Cargo_Capacity { get; set; }
        public string Consumables { get; set; }
        public IList<string> Pilots { get; set; }
        public IList<string> Films {get; set;}
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
