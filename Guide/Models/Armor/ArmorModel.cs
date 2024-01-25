namespace Guide.Models.Armor
{
    public class ArmorModel
    {
        public ArmorModel(int id)
        {
            //Id = id;
            //Name = name;
            //Rarity = rarity;
            //Class = @class;
            //Weight = weight;
            //Properties = properties;
            //Stats = stats;
            //CompatibleBackpacks = compatibleBackpacks;
            //CompatibleContainers = compatibleContainers;
            //BarterBase = barterBase;
            //Barters = barters;
            //UsedInID = usedInID;
            //Description = description;
            //ImgSource = $"https://github.com/EXBO-Studio/stalcraft-database/blob/main/global/icons/armor/{class}/{id}.png";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Class { get; set; }
        public string Weight { get; set; }
        public List<string> Properties { get; set; }
        public List<string> Stats { get; set; }
        public string CompatibleBackpacks { get; set; }
        public string CompatibleContainers { get; set; }
        public Dictionary<string, string> BarterBase { get; set; }
        public List<Barter> Barters { get; set; }
        public List<string> UsedInID { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }

    }
}
