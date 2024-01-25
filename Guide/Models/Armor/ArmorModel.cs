namespace Guide.Models.Armor
{
    public class ArmorModel
    {
        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Class { get; set; }
        public string Weight { get; set; }
        public List<string> Properties { get; set; }
        public List<string> Stats { get; set; }
        public string CompatibleBackpacks { get; set; }
        public string CompatibleContainers { get; set; }
        public string Description { get; set; }

    }
}
