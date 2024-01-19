namespace Guide.Models
{
    public class ArtifactContainer : IItem
    {
        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public int Protection { get; set; }
        public int CarryWeight { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, int> BarterBase { get; set; }
        public List<Barter> Barters { get; set; }
        public string Description { get; set; }
        public ArtifactContainer(string imgSource, string name, int protection, int carryWeight, string @class, double weight, Dictionary<string, int> barterBase, List<Barter> barters, string description)
        {
            ImgSource = imgSource;
            Name = name;
            Protection = protection;
            CarryWeight = carryWeight;
            Class = @class;
            Weight = weight;
            BarterBase = barterBase;
            Barters = barters;
            Description = description;
        }
    }
}
