using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class StarshipModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Cost_In_Credits { get; set; }
        public string Length { get; set; }
        public string Max_Atmosphering_Speed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string Cargo_Capcity { get; set; }
        public string Consumables { get; set; }
        public string Hyperdrive_Rating { get; set; }
        public string MGLT { get; set; }
        public string Starship_Class { get; set; }
        public IList<string> Pilots { get; set; }
        public IList<string> Films { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
        public string EntityId { get; set; }
    }
}
