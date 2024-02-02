using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
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
            List<string> armorPaths = new List<string>();
            List<ArmorModel> armors = new List<ArmorModel>();
            foreach (string file in Directory.EnumerateFiles($"C:\\Users\\a\\Desktop\\SOFA\\Guide\\Guide\\Database\\items\\armor\\{category}", "*.*", SearchOption.TopDirectoryOnly))
            {
                armorPaths.Add(file);
                string jsonString = new Json().Reader(file);
                var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/{jObject["category"]}/{jObject["id"].Value<string>()}.png");
                request.Method = "HEAD";
                try
                {
                    request.GetResponse();
                    ArmorModel armorModel = new ArmorModel(jsonString);
                    armors.Add(armorModel);
                }
                catch { }
            }
            return armors;
        }



        public ArmorModel() { }
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public ArmorModel(string jsonString)
        {
            var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
            Id = jObject["id"]
                .Value<string>();
            Console.WriteLine("Id: " + Id);
            Name = jObject["name"]
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("Name: " + Name);
            Rarity = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[0]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("Rarity: " + Rarity);
            Class = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[1]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("Class: " + Class);
            Weight = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[2]
                .Value<double>("value");
            Console.WriteLine("Weight: " + Weight);
            //Properties = properties;
            //Stats = stats;
            int ifHasFeature = 0;
            if (jObject["infoBlocks"][4]
                .Value<JObject>("title")
                .Value<JObject>("lines")
                .Value<string>("en") == "Features")
            {
                ifHasFeature = 1;
            }
            CompatibleBackpacks = jObject["infoBlocks"][4 + ifHasFeature]
                .Value<JObject>("text")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("CompatibleBackpacks: " + CompatibleBackpacks);
            CompatibleContainers = jObject["infoBlocks"][5 + ifHasFeature]
                .Value<JObject>("text")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("CompatibleContainers: " + CompatibleContainers);
            //BarterBase = barterBase;
            //Barters = barters;
            //UsedInID = usedInID;
            Description = jObject["infoBlocks"][6]
                .Value<JObject>("text")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("Description: " + Description);
            ImgSource = $"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/{jObject["category"]}/{Id}.png";
            Console.WriteLine("ImgSource: " + ImgSource);
            Console.WriteLine("");
        }
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        public string Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
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
