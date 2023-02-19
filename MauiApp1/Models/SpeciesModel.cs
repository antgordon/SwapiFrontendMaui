namespace MauiApp1.Models
{
    public class SpeciesModel
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public double Average_Height { get; set; }
        public int Average_Lifespan { get; set; }
        public string Eye_Colors { get; set; }
        public string Hair_colors { get; set; }
        public string Skin_Colors { get; set; }
        public string Language { get; set; }
        public string Homeworld { get; set; }
        public IList<string> People { get; set; }
        public IList<string> Films {get; set;}
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
