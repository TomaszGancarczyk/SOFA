using System.IO;
using System.Text.Json;

namespace Guide.Models.Armor
{
    public class ArmorModel
    {
        public List<ArmorModel> GetAllArmors()
        {
            List<ArmorModel> allArmors = new List<ArmorModel>();
            foreach (ArmorModel clothes in GetArmorCategory("clothes"))
            {
                allArmors.Add(clothes);
            }
            foreach (ArmorModel combat in GetArmorCategory("combat"))
            {
                allArmors.Add(combat);
            }
            foreach (ArmorModel combined in GetArmorCategory("combined"))
            {
                allArmors.Add(combined);
            }
            foreach (ArmorModel scientist in GetArmorCategory("scientist"))
            {
                allArmors.Add(scientist);
            }
            return allArmors;
        }
        public List<ArmorModel> GetArmorCategory(string category)
        {
            Console.WriteLine("Getting files:");
            Console.WriteLine("");
            List<string> armorPaths = new List<string>();
            foreach (string file in Directory.EnumerateFiles($"C:\\Users\\a\\Desktop\\SOFA\\Guide\\Guide\\Database\\items\\armor\\{category}", "*.*", SearchOption.TopDirectoryOnly))
            {
                Console.WriteLine(file);
                armorPaths.Add(file);
                string jsonString = new Json().Reader(file);
                ArmorModel? armorModel = JsonSerializer.Deserialize<ArmorModel>(jsonString);
                Console.WriteLine(armorModel.id);
            }
            List<ArmorModel> armors = new List<ArmorModel>();
            foreach (string filePath in armorPaths)
            {
                string[] collection = filePath.Split('\\');
                string id = collection.Last();
                collection = id.Split('.');
                id = collection[0];
                ArmorModel armormodel = new ArmorModel(id);
                armors.Add(armormodel);
            }
            return armors;
        }



    public ArmorModel() { }
    public ArmorModel(string file)
        {
            this.id = id;
            //name = name;
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

        public string id { get; set; }
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
