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
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        public ArmorModel(string jsonString)
        {
            //define jobject
            var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
            //check if has features
            int ifHasFeature = 0;
            if (jObject["infoBlocks"][4]
                .Value<JObject>("title")
                .Value<JObject>("lines")
                .Value<string>("en") == "Features")
            {
                ifHasFeature = 1;
            }
            //armor model
            //id
            Id = jObject["id"]
                .Value<string>();
            Console.WriteLine("Id: " + Id);
            //name
            Name = jObject["name"]
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("Name: " + Name);
            //rarity
            Rarity = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[0]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("Rarity: " + Rarity);
            //class
            Class = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[1]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("Class: " + Class);
            //weight
            Weight = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[2]
                .Value<double>("value");
            Console.WriteLine("Weight: " + Weight);
            //features
            List<string> features = new List<string>();
            if (ifHasFeature == 1)
            {
                var jsonFeatures = jObject["infoBlocks"][4]
                .Value<JArray>("elements");
                foreach (var feature in jsonFeatures)
                {
                    features.Add(
                    feature
                    .Value<JObject>("text")
                    .Value<JObject>("lines")
                    .Value<string>("en"));
                }
            }
            Features = features;
            Console.WriteLine("Features: ");
            foreach (var feature in Features)
            {
                Console.WriteLine(feature);
            }
            //properties
            Dictionary<string, int> properties = new Dictionary<string, int>();
            var jsonProperties = jObject["infoBlocks"][2]
                .Value<JArray>("elements");
            foreach (var property in jsonProperties)
            {
                string propertyName = "";
                int propertyValue = 0;
                if (property.Value<string>("type") == "text")
                {
                    propertyName = property
                    .Value<JObject>("text")
                    .Value<JObject>("lines")
                    .Value<string>("en");
                }
                else
                {
                    propertyName = property
                    .Value<JObject>("name")
                    .Value<JObject>("lines")
                    .Value<string>("en");
                    propertyValue = property
                        .Value<int>("value");
                }
                if (propertyName != "")
                {
                    properties.Add(propertyName, propertyValue);
                }
            }
            Properties = properties;
            Console.WriteLine("Properties: ");
            foreach (var property in Properties)
            {
                Console.WriteLine($"{property.Key} : {property.Value}");
            }
            //stats
            Dictionary<string, int> stats = new Dictionary<string, int>();
            var jsonStats = jObject["infoBlocks"][3]
                .Value<JArray>("elements");
            foreach (var stat in jsonStats)
            {
                stats.Add(
                    stat
                    .Value<JObject>("name")
                    .Value<JObject>("lines")
                    .Value<string>("en"),
                    stat
                    .Value<int>("value"));
            }
            Stats = stats;
            Console.WriteLine("Stats: ");
            foreach (var stat in Stats)
            {
                Console.WriteLine($"{stat.Key} : {stat.Value}");
            }
            //backpacks
            CompatibleBackpacks = jObject["infoBlocks"][4 + ifHasFeature]
                .Value<JObject>("text")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("CompatibleBackpacks: " + CompatibleBackpacks);
            //containers
            CompatibleContainers = jObject["infoBlocks"][5 + ifHasFeature]
                .Value<JObject>("text")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("CompatibleContainers: " + CompatibleContainers);

            //BarterBase = barterBase;

            //Barters = barters;

            //UsedInID = usedInID;

            //description
            Description = jObject["infoBlocks"][6 + ifHasFeature]
                .Value<JObject>("text")
                .Value<JObject>("lines")
                .Value<string>("en");
            Console.WriteLine("Description: " + Description);
            //image source
            ImgSource = $"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/{jObject["category"]}/{Id}.png";
            Console.WriteLine("ImgSource: " + ImgSource);
            Console.WriteLine("");
        }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        public string Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public List<string> Features { get; set; }
        public Dictionary<string, int> Properties { get; set; }
        public Dictionary<string, int> Stats { get; set; }
        public string CompatibleBackpacks { get; set; }
        public string CompatibleContainers { get; set; }
        public Dictionary<string, string> BarterBase { get; set; }
        public List<Barter> Barters { get; set; }
        public List<string> UsedInID { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }

    }
}
