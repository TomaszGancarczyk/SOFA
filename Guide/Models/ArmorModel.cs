using Guide.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Guide.Models
{
    public class ArmorModel : IItem
    {
        public List<ArmorModel> AllArmors { get; set; }
        public List<ArmorModel> GetAllArmors(string databasePath)
        {
            AllArmors =
                [
                    .. CreateArmorCategory("clothes", databasePath),
                    .. CreateArmorCategory("combat", databasePath),
                    .. CreateArmorCategory("combined", databasePath),
                    .. CreateArmorCategory("scientist", databasePath),
                ];
            return AllArmors;
        }

        public List<ArmorModel> CreateArmorCategory(string category, string databasePath)
        {
            List<ArmorModel> armors = [];
            BarterModel bases = BarterModel.GetBarter(Shared.GetEuDatabasePath());
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\armor\\{category}", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                if (JsonConvert.DeserializeObject(jsonString) is not JObject jObject)
                {
                    Console.WriteLine($"Jobject is null for: {file}");
                    continue;
                }
                bool ifImageExists = false;
                string? objectId = jObject["id"].Value<string>();
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\armor\\{category}\\{objectId}.png");
                if (ifImageExists)
                {
                    ArmorModel armorModel = new(jObject, file);
                    foreach (var factionBase in bases.Bases)
                    {
                        foreach (var offer in factionBase.Barters)
                        {
                            if (offer.ItemId == objectId)
                            {
                                ItemBarter barter = new()
                                {
                                    RequiredLevel = offer.RequiredLevel,
                                    BaseName = factionBase.BaseName,
                                    Offers = offer.Offers
                                };
                                armorModel.Barter = barter;
                                factionBase.Barters.Remove(offer);
                                break;
                            }
                        }
                    }
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
        public ArmorModel(JObject jObject, string file)
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

            //upgrades
            Dictionary<int, Dictionary<string, string>> upgradeStats = [];
            List<string> fileList = file.Split(".").ToList();
            file = fileList[0];
            fileList = file.Split("\\").ToList();
            fileList.Insert(fileList.Count - 1, "_variants");
            file = "";
            foreach (string filePart in fileList)
                file += $"{filePart}\\";
            int upgradeCount = 1;
            foreach (string upgradeFile in Directory.EnumerateFiles(file, "*.*", SearchOption.TopDirectoryOnly))
            {
                jObject = (JObject)JsonConvert.DeserializeObject(Shared.Reader(upgradeFile));
                stats = [];
                var upgradeJsonStats = jObject["infoBlocks"][3]
                .Value<JArray>("elements");
                foreach (var stat in upgradeJsonStats)
                {
                    stats.Add(
                        stat
                        .Value<JObject>("name")
                        .Value<JObject>("lines")
                        .Value<string>("en"),
                        stat
                        .Value<string>("value"));
                }
                upgradeStats.Add(upgradeCount, stats);
                upgradeCount++;
            }
            UpgradeStats = upgradeStats;
        }
#pragma warning disable CS8603 // Possible null reference return.

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
        public Dictionary<int, Dictionary<string, string>> UpgradeStats { get; set; }
        public ItemBarter Barter { get; set; }
        WeaponModel.DamageGraph IItem.DamageGraphField { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, Dictionary<double, double>> IItem.ArtefactStats { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, Dictionary<double, double>> IItem.PossibleArtefactStats { get => null; set => throw new NotImplementedException(); }
        List<string> IItem.SuitableFor { get => null; set => throw new NotImplementedException(); }
        List<string> IItem.AttachmentAmmoType { get => null; set => throw new NotImplementedException(); }
        string IItem.Obtained { get => null; set => throw new NotImplementedException(); }
    }
}
