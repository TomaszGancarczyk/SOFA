using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Channels;
using Microsoft.IdentityModel.Tokens;
using Guide.Services;

namespace Guide.Models
{
    public class BulletModel : IItem
    {
        public List<BulletModel> GetAllBullets()
        {
            string databasePath = new Shared().GetDatabasePath();
            List<string> bulletPaths = [];
            List<BulletModel> bullets = [];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\bullet", "*.*", SearchOption.TopDirectoryOnly))
            {
                bulletPaths.Add(file);
                string jsonString = new Json().Reader(file);
                var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
                bool ifImageExists = File.Exists($"{databasePath}icons\\bullet\\{jObject["id"].Value<string>()}.png");
                if (ifImageExists)
                {
                    BulletModel bulletsModel = new(jObject);
                    bullets.Add(bulletsModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {jObject["id"].Value<string>()} doesn't exist");
                }
            }
            return bullets;
        }
        public BulletModel() { }
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public BulletModel(JObject jObject)
        {
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

            //stats
            Dictionary<string, string> stats = [];
            int hasMultipleProjectiles = 0;
            if (jObject["infoBlocks"].Count() == 5)
            {
                var numberOfProjectiles = jObject["infoBlocks"][3]
                .Value<JArray>("elements");
                foreach (var stat in numberOfProjectiles)
                {
                    stats.Add(
                    stat
                    .Value<JObject>("name")
                    .Value<JObject>("lines")
                    .Value<string>("en"),
                    stat
                    .Value<JObject>("formatted")
                    .Value<JObject>("value")
                    .Value<string>("en"));
                }
                hasMultipleProjectiles = 1;
            }
            var jsonStats = jObject["infoBlocks"][3 + hasMultipleProjectiles]
                .Value<JArray>("elements");
            foreach (var stat in jsonStats)
            {
                stats.Add(
                    stat
                    .Value<JObject>("name")
                    .Value<JObject>("lines")
                    .Value<string>("en"),
                    stat
                    .Value<JObject>("formatted")
                    .Value<JObject>("value")
                    .Value<string>("en"));
            }
            Stats = stats;



            //features
            List<string> features = [];
            var jsonFeatures = jObject["infoBlocks"][2]
                .Value<JArray>("elements");
            foreach (var feature in jsonFeatures)
            {
                features.Add(feature
                    .Value<JObject>("text")
                    .Value<JObject>("lines")
                    .Value<string>("en"));
            }
            Features = features;



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
        public string Rarity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Class { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, string> Stats { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
        public List<string> Features { get; set; }
        public Dictionary<string, int> Properties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CompatibleBackpacks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CompatibleContainers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, Dictionary<double, double>> ArtefactStats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, int> PossibleArtefactStats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> SuitableFor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Dictionary<string, Dictionary<double, double>> IItem.PossibleArtefactStats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> AttachmentAmmoType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
