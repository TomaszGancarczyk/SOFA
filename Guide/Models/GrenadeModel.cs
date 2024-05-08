using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Channels;
using Guide.Services;

namespace Guide.Models
{
    public class GrenadeModel : IItem
    {
        public List<GrenadeModel> GetAllGrenades(string databasePath)
        {
            List<GrenadeModel> grenades = [];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\grenade", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                var jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\grenade\\{objectId}.png");
                if (ifImageExists)
                {
                    GrenadeModel grenadeModel = new(jObject);
                    grenades.Add(grenadeModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {objectId} doesn't exist");
                }
            }
            return grenades;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public GrenadeModel() { }
        public GrenadeModel(JObject jObject)
        {
            //check if has description
            int ifHasdescription = 0;
            if (jObject["infoBlocks"][jObject["infoBlocks"].Count() - 1].Value<string>("type") == "text")
            {
                ifHasdescription = 1;
            }
            //check if has feature
            int ifHasFeature = 0;
            if (jObject["infoBlocks"].Count() == 4 + ifHasdescription)
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
            //class
            Class = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[0]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            //weight
            Weight = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[1]
                .Value<double>("value");
            //features
            List<string> features = [];
            if (ifHasFeature == 1)
            {
                features.Add(jObject["infoBlocks"][2]
                .Value<JObject>("text")
                .Value<JObject>("lines")
                .Value<string>("en"));
            }
            Features = features;
            //stats
            Dictionary<string, string> stats = [];
            var jsonStats = jObject["infoBlocks"][2 + ifHasFeature]
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
            //description
            if (ifHasdescription == 1)
            {
                Description = jObject["infoBlocks"][jObject["infoBlocks"].Count() - 1]
                                .Value<JObject>("text")
                                .Value<JObject>("lines")
                                .Value<string>("en");
            }
            else Description = "";
            //image source
            ImgSource = $"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/{jObject["category"]}/{Id}.png";
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, string> Stats { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
        public List<string> Features { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
