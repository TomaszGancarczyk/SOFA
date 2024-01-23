using Guide.Models.Interfaces;
using Guide.Models.Objects.BackpackAndContainerObject;

namespace Guide.Models
{
    public class Armor : IItem
    {

        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public Dictionary<string, int> Properties { get; set; }
        public List<ArmorProperties> AdditionalProperties { get; set; }
        public List<BackpackObject> CompatibleBackpacks { get; set; }
        public List<ArtifactContainerObject> CompatibleContainers { get; set; }
        public string Class { get; set; }
        public string Rarity { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, string> BarterBase { get; set; }
        public List<Barter> Barters { get; set; }
        public List<IBarter> UsedIn { get; set; }
        public string Description { get; set; }
        public Armor(string imgSource, string name, Dictionary<string, int> properties, List<ArmorProperties> additionalProperties, List<BackpackObject> compatibleBackpacks, List<ArtifactContainerObject> compatibleContainers, string @class, string rarity, double weight, Dictionary<string, string> barterBase, List<Barter> barters, List<IBarter> usedIn, string description)
        {
            ImgSource = imgSource;
            Name = name;
            Properties = properties;
            AdditionalProperties = additionalProperties;
            CompatibleBackpacks = compatibleBackpacks;
            CompatibleContainers = compatibleContainers;
            Class = @class;
            Rarity = rarity;
            Weight = weight;
            BarterBase = barterBase;
            Barters = barters;
            UsedIn = usedIn;
            Description = description;
        }
    }
    public class ArmorProperties
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public bool IsPositive { get; set; }
        public ArmorProperties(string propertyName, double value, bool isPositive)
        {
            Name = propertyName;
            Value = value;
            IsPositive = isPositive;
        }
    }
}
