using Guide.Models.Interfaces;

namespace Guide.Models
{
    public class Backpack : IItem
    {
        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public int Protection { get; set; }
        public int CarryWeight { get; set; }
        public string Class { get; set; }
        public string Rarity { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, int> BarterBase { get; set; }
        public List<Barter> Barters { get; set; }
        public string Description { get; set; }
    }
}
