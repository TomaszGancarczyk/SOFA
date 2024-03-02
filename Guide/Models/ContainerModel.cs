using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Channels;
using Guide.Services;

namespace Guide.Models
{
    public class ContainerModel : IItem
    {
        public List<ContainerModel> GetAllContainers()
        {
            string databasePath = Shared.GetDatabasePath();
            List<string> containerPaths = [];
            List<ContainerModel> containers = [];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\containers", "*.*", SearchOption.TopDirectoryOnly))
            {
                containerPaths.Add(file);
                string jsonString = Shared.Reader(file);
                var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
                bool ifImageExists = File.Exists($"{databasePath}icons\\containers\\{jObject["id"].Value<string>()}.png");
                if (ifImageExists)
                {
                    ContainerModel containerModel = new(jObject);
                    containers.Add(containerModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {jObject["id"].Value<string>()} doesn't exist");
                }
            }
            return containers;
        }
        public ContainerModel() { }
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public ContainerModel(JObject jObject)
        {
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
            //description
            if (jObject["infoBlocks"][jObject["infoBlocks"].Count() - 1].Value<string>("type") == "text")
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
        public string Rarity { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, string> Stats { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
    }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
