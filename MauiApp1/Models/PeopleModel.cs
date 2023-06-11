using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class PeopleModel
    {

        public string Name { get; set; }
        public double? Height { get; set; }
        public double? Mass { get; set; }
        public string Hair_Color { get; set; }
        public string Skin_Color { get; set; }
        public string Eye_Color { get; set; }
        public string Birth_Year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public IList<string> Films { get; set; }
        public IList<string> Species { get; set; }
        public IList<string> Vehicles { get; set; }
        public IList<string> Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
        public string EntityId { get; set; }

        public IList<EntityIdentifier> RelatedEntities { get; set; }
    }
}
