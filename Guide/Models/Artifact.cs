namespace Guide.Models
{
    public class Artifact
    {

        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public List<Properties> PropertiesList { get; set; }
        public List<Properties> PotentialPropertiesList { get; set; }
        public string Description { get; set; }

        public Artifact(string imgSource, string name, string @class, double weight, List<Properties> properties, List<Properties> potentialProperties, string description)
        {
            ImgSource = imgSource;
            Name = name;
            Class = @class;
            Weight = weight;
            PropertiesList = properties;
            PotentialPropertiesList = potentialProperties;
            Description = description;
        }
    }
    public class Properties
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public bool IsPositive { get; set; }
        public Properties(string propertyName, double value, bool isPositive)
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
