using Guide.Models.Interfaces;

namespace Guide.Models
{
    public class ArtifactContainer : IItem
    {
        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public double Protection { get; set; }
        public int CarryWeight { get; set; }
        public string Class { get; set; }
        public string Rarity { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, string> BarterBase { get; set; }
        public List<Barter> Barters { get; set; }
        public string Description { get; set; }
        public ArtifactContainer(string imgSource, string name, double protection, int carryWeight, string @class, string rarity, double weight, Dictionary<string, string> barterBase, List<Barter> barters, string description)
        {
            ImgSource = imgSource;
            Name = name;
            Protection = protection;
            CarryWeight = carryWeight;
            Class = @class;
            Rarity = rarity;
            Weight = weight;
            BarterBase = barterBase;
            Barters = barters;
            Description = description;
        }
    }
}
