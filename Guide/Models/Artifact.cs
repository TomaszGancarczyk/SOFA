using Guide.Models.Interfaces;

namespace Guide.Models
{
    public class Artifact : IItem
    {

        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public List<ArtifactProperties> PropertiesList { get; set; }
        public List<ArtifactProperties> PotentialPropertiesList { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Artifact(string imgSource, string name, string @class, double weight, int price, List<ArtifactProperties> properties, List<ArtifactProperties> potentialProperties, string description)
        {
            ImgSource = imgSource;
            Name = name;
            Class = @class;
            Weight = weight;
            Price = price;
            PropertiesList = properties;
            PotentialPropertiesList = potentialProperties;
            Description = description;
        }
    }
    public class ArtifactProperties
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public bool IsPositive { get; set; }
        public ArtifactProperties(string propertyName, double value, bool isPositive)
        {
            Name = propertyName;
            Value = value;
            IsPositive = isPositive;
        }
    }
    public class PotentialProperties
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public bool IsPositive { get; set; }
        public PotentialProperties(string propertyName, double value, bool isPositive)
        {
            Name = propertyName;
            Value = value;
            IsPositive = isPositive;
        }
    }
}
