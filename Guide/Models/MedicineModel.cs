using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Channels;
using Microsoft.IdentityModel.Tokens;
using Guide.Services;

namespace Guide.Models
{
    public class MedicineModel : IItem
    {
        public List<MedicineModel> GetAllMedicines(string databasePath)
        {
            List<MedicineModel> medicines = [];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\medicine", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                var jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\medicine\\{objectId}.png");
                if (ifImageExists)
                {
                    MedicineModel medicineModel = new(jObject);
                    medicines.Add(medicineModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {objectId} doesn't exist");
                }
            }
            return medicines;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public MedicineModel() { }
        public MedicineModel(JObject jObject)
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
            //features
            List<string> features = [];
            Dictionary<string, string> stats = [];
            var jsonFeatures = jObject["infoBlocks"][2]
                .Value<JArray>("elements");
            foreach (var feature in jsonFeatures)
            {
                if (feature.Value<string>("type") == "numeric")
                {
                    stats.Add(
                    feature
                    .Value<JObject>("name")
                    .Value<JObject>("lines")
                    .Value<string>("en"),
                    feature
                    .Value<JObject>("formatted")
                    .Value<JObject>("value")
                    .Value<string>("en"));
                }
                else
                {
                    features.Add(feature
                        .Value<JObject>("value")
                        .Value<JObject>("lines")
                        .Value<string>("en"));
                }
            }
            Features = features;
            //stats
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
                    .Value<JObject>("formatted")
                    .Value<JObject>("value")
                    .Value<string>("en"));
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
