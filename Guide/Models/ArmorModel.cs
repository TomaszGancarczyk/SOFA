using Guide.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Guide.Models
{
    public class ArmorModel : IItem
    {
        public List<ArmorModel> AllArmors { get; set; }
        public List<ArmorModel> GetAllArmors()
        {
            AllArmors =
                [
                    .. CreateArmorCategory("clothes"),
                    .. CreateArmorCategory("combat"),
                    .. CreateArmorCategory("combined"),
                    .. CreateArmorCategory("scientist"),
                ];
            return AllArmors;
        }

        public List<ArmorModel> CreateArmorCategory(string category)
        {
            string databasePath = Shared.GetEuDatabasePath();
            List<ArmorModel> armors = [];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\armor\\{category}", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                var jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\armor\\{category}\\{objectId}.png");
                if (ifImageExists)
                {
                    ArmorModel armorModel = new(jObject);
                    armors.Add(armorModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {objectId} doesn't exist");
                }
            }
            return armors;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        public ArmorModel() { }
        public ArmorModel(JObject jObject)
        {
            //check if has features
            int ifHasFeature = 0;
            if (jObject["infoBlocks"][4]
                .Value<JObject>("title")
                .Value<JObject>("lines")
                .Value<string>("en") == "Features")
            {
                ifHasFeature = 1;
            }
            //id
            Id = jObject["id"]
                .Value<string>();
            //name
            Name = jObject["name"]
                .Value<JObject>("lines")
                .Value<string>("en");
            //rarity
            Rarity = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[0]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            //class
            Class = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[1]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            //weight
            Weight = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[2]
                .Value<double>("value");
            //features
            List<string> features = [];
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
            //properties
            Dictionary<string, int> properties = [];
            var jsonProperties = jObject["infoBlocks"][2]
                .Value<JArray>("elements");
            foreach (var property in jsonProperties)
            {
                string propertyName;
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
            //stats
            Dictionary<string, string> stats = [];
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
                    .Value<string>("value"));
            }
            Stats = stats;
            //backpacks
            CompatibleBackpacks = jObject["infoBlocks"][4 + ifHasFeature]
                .Value<JObject>("text")
                .Value<JObject>("lines")
                .Value<string>("en");
            //containers
            CompatibleContainers = jObject["infoBlocks"][5 + ifHasFeature]
                .Value<JObject>("text")
                .Value<JObject>("lines")
                .Value<string>("en");
            //description
            if (jObject["infoBlocks"][jObject["infoBlocks"].Count() - 1].Value<string>("type") == "text")
            {
                Description = jObject["infoBlocks"][jObject["infoBlocks"].Count() - 1]
                                .Value<JObject>("text")
                                .Value<JObject>("lines")
                                .Value<string>("en");
            }
            //image source
            ImgSource = $"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/{jObject["category"]}/{Id}.png";
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
        public Dictionary<string, string> Stats { get; set; }
        public string CompatibleBackpacks { get; set; }
        public string CompatibleContainers { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
    }
}
