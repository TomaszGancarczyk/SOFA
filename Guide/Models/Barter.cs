using Guide.Models.Interfaces;

namespace Guide.Models
{
    public class BarterItem : IBarter
    {

        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public string Obtained { get; set; }
        public string Description { get; set; }
        public BarterItem(string imgSource, string name, string rarity, int price, double weight, string obtained, string description)
        {
            ImgSource = imgSource;
            Name = name;
            Rarity = rarity;
            Price = price;
            Weight = weight;
            Obtained = obtained;
            Description = description;
        }
    }
    public class Barter
    {
        public int Cost { get; set; }
        public Dictionary<IBarter, int> BarterResources { get; set; }

        public Barter(int cost, Dictionary<IBarter, int> barterResources)
        {
            Cost = cost;
            BarterResources = barterResources;
        }
    }
}
