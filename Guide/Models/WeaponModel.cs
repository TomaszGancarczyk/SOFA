using Guide.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Guide.Models
{
    public class WeaponModel : IItem
    {
        public List<WeaponModel> AllWeapons { get; set; }
        public List<WeaponModel> GetAllWeapons(string databasePath)
        {
            AllWeapons =
                [
                    .. CreateWeaponCategory("assault_rifle", databasePath),
                    .. CreateWeaponCategory("device", databasePath),
                    .. CreateWeaponCategory("heavy", databasePath),
                    .. CreateWeaponCategory("machine_gun", databasePath),
                    .. CreateWeaponCategory("melee", databasePath),
                    .. CreateWeaponCategory("pistol", databasePath),
                    .. CreateWeaponCategory("shotgun_rifle", databasePath),
                    .. CreateWeaponCategory("sniper_rifle", databasePath),
                    .. CreateWeaponCategory("submachine_gun", databasePath),
                ];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\other\\device", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                JObject jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                AllWeapons.Add(new WeaponModel(jObject, file));
            }
            return AllWeapons;
        }

        public List<WeaponModel> CreateWeaponCategory(string category, string databasePath)
        {
            List<WeaponModel> weapons = [];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\weapon\\{category}", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                JObject jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\weapon\\{category}\\{objectId}.png");
                if (ifImageExists)
                {
                    WeaponModel weaponModel = new(jObject, file);
                    weapons.Add(weaponModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {objectId} doesn't exist");
                }
            }
            return weapons;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        public WeaponModel() { }
        public WeaponModel(JObject jObject, string file)
        {
            //check if has rarity
            int ifHasRarity = 0;
            if (jObject["infoBlocks"][0]
                    .Value<JArray>("elements")[0]
                    .Value<JObject>("key")
                    .Value<JObject>("lines")
                    .Value<string>("en") == "Rank")
                ifHasRarity = 1;
            //check if has type
            int ifHasType = 0;
            if (jObject["infoBlocks"][0]
                    .Value<JArray>("elements")[2]
                    .Value<string>("type") == "key-value")
            {
                if (jObject["infoBlocks"][0]
                    .Value<JArray>("elements")[2]
                    .Value<JObject>("key")
                    .Value<JObject>("lines")
                    .Value<string>("en") == "Type")
                {
                    ifHasType = 1;
                }
            }
            //id
            Id = jObject["id"]
            .Value<string>();
            //name
            Name = jObject["name"]
            .Value<JObject>("lines")
            .Value<string>("en");
            //rarity
            if (ifHasRarity == 1)
            {
                Rarity = jObject["infoBlocks"][0]
                    .Value<JArray>("elements")[0]
                    .Value<JObject>("value")
                    .Value<JObject>("lines")
                    .Value<string>("en");
            }
            //class
            Class = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[0 + ifHasRarity]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            //weight
            Weight = jObject["infoBlocks"][0]
        .Value<JArray>("elements")[2 + ifHasType]
        .Value<double>("value");
            //check if object is device
            bool isDevice = false;
            if (Class == "Devices")
            {
                isDevice = true;
            }
            //stats
            Dictionary<string, string> stats = [];
            List<string> features = [];
            var jsonStats = jObject["infoBlocks"][2]
                .Value<JArray>("elements");
            foreach (var stat in jsonStats)
            {
                if (stat.Value<string>("type") == "key-value")
                {
                    stats.Add(
                    stat
                    .Value<JObject>("key")
                    .Value<JObject>("lines")
                    .Value<string>("en"),
                    stat
                    .Value<JObject>("value")
                    .Value<JObject>("lines")
                    .Value<string>("en"));
                }
                else if (stat.Value<string>("type") == "text")
                {
                    features.Add(
                        stat
                    .Value<JObject>("text")
                    .Value<JObject>("lines")
                    .Value<string>("en"));
                }
                else if (stat.Value<string>("type") == "numeric")
                {
                    stats.Add(stat
                            .Value<JObject>("name")
                            .Value<JObject>("lines")
                            .Value<string>("en"),
                        stat
                            .Value<JObject>("formatted")
                            .Value<JObject>("value")
                            .Value<string>("en"));
                }
            }
            if (!isDevice && Class != "Other")
                Stats = stats;
            else
            {
                Features = features;
            }
            //damage modifier
            if (!isDevice && Class != "Other")
            {
                //features
                var jsonFeatures = jObject["infoBlocks"][5 - ifHasType]
                     .Value<JArray>("elements");
                if (jsonFeatures.Count > 0)
                {
                    foreach (JToken feature in jsonFeatures)
                    {
                        if (Class != "Other Weapons")
                        {
                            if (feature.Value<String>("type") != "numeric")
                            {
                                features.Add(feature
                                .Value<JObject>("text")
                                .Value<JObject>("lines")
                                .Value<string>("en"));
                            }
                            else
                            {
                                features.Add($"{feature
                                        .Value<JObject>("name")
                                        .Value<JObject>("lines")
                                        .Value<string>("en")}: {feature
                                        .Value<JObject>("formatted")
                                        .Value<JObject>("value")
                                        .Value<string>("en")}"
                                    );
                            }
                        }
                        else
                        {
                            if (feature.Value<string>("type") != "text")
                            {
                                features.Add($"{feature
                                        .Value<JObject>("name")
                                        .Value<JObject>("lines")
                                        .Value<string>("en")}: {feature
                                        .Value<JObject>("formatted")
                                        .Value<JObject>("value")
                                        .Value<string>("en")}"
                                    );
                            }
                        }

                    }
                }
                var jsonOtherFeatures = jObject["infoBlocks"][4]
                             .Value<JArray>("elements");
                if (jsonOtherFeatures.Count > 0)
                {
                    foreach (var otherFeature in jsonOtherFeatures)
                    {
                        if (otherFeature.Value<String>("type") == "numeric")
                        {
                            features.Add($"{otherFeature
                                    .Value<JObject>("name")
                                    .Value<JObject>("lines")
                                    .Value<string>("en")}: {otherFeature
                                    .Value<JObject>("formatted")
                                    .Value<JObject>("value")
                                    .Value<string>("en")}");
                        }
                        else
                        {
                            features.Add(otherFeature
                            .Value<JObject>("text")
                            .Value<JObject>("lines")
                            .Value<string>("en"));
                        }
                    }
                }
                Features = features.Distinct().ToList();
                //damage graph
                if (Class != "Other Weapons" && Class != "Melee Weapons")
                {
                    DamageGraph = new DamageGraph(
                jObject["infoBlocks"][6]
                    .Value<double>("startDamage"),
                jObject["infoBlocks"][6]
                    .Value<double>("damageDecreaseStart"),
                jObject["infoBlocks"][6]
                    .Value<double>("endDamage"),
                jObject["infoBlocks"][6]
                    .Value<double>("damageDecreaseEnd"),
                jObject["infoBlocks"][6]
                    .Value<double>("maxDistance")
                    );
                }
            }
            else if (isDevice)
            {
                //stats
                int shortStatsFix = 0;
                if (Class == "Melee Weapons")
                {
                    shortStatsFix = -1;
                }
                if (jObject["infoBlocks"][4].Value<string>("type") == "list" && isDevice)
                {
                    shortStatsFix = 1;
                }
                jsonStats = jObject["infoBlocks"][3 + shortStatsFix]
                                     .Value<JArray>("elements");
                foreach (var stat in jsonStats)
                {
                    stats.Add(stat
                    .Value<JObject>("name")
                        .Value<JObject>("lines")
                        .Value<string>("en"),
                     stat
                    .Value<JObject>("formatted")
                        .Value<JObject>("value")
                        .Value<string>("en"));
                }
            }
            else Class = "Devices";
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
            if (Directory.Exists(file))
            {
                foreach (string upgradeFile in Directory.EnumerateFiles(file, "*.*", SearchOption.TopDirectoryOnly))
                {
                    jObject = (JObject)JsonConvert.DeserializeObject(Shared.Reader(upgradeFile));
                    stats = [];
                    var upgradeJsonStats = jObject["infoBlocks"][2]
                        .Value<JArray>("elements");
                    foreach (var stat in upgradeJsonStats)
                    {
                        if (stat.Value<string>("type") == "key-value")
                        {
                            stats.Add(
                            stat
                            .Value<JObject>("key")
                            .Value<JObject>("lines")
                            .Value<string>("en"),
                            stat
                            .Value<JObject>("value")
                            .Value<JObject>("lines")
                            .Value<string>("en"));
                        }
                        else if (stat.Value<string>("type") == "text")
                        {
                            features.Add(
                                stat
                            .Value<JObject>("text")
                            .Value<JObject>("lines")
                            .Value<string>("en"));
                        }
                        else if (stat.Value<string>("type") == "numeric")
                        {
                            stats.Add(stat
                                    .Value<JObject>("name")
                                    .Value<JObject>("lines")
                                    .Value<string>("en"),
                                stat
                                    .Value<JObject>("formatted")
                                    .Value<JObject>("value")
                                    .Value<string>("en"));
                        }
                    }
                    if (!isDevice && Class != "Other")
                        upgradeStats.Add(upgradeCount, stats);
                    upgradeCount++;
                }
            }
            UpgradeStats = upgradeStats;
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
        public Dictionary<string, string> Stats { get; set; }
        public DamageGraph DamageGraph { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
        public Dictionary<int, Dictionary<string, string>> UpgradeStats { get; set; }
    }
    public class DamageGraph(double startDamage, double damageDecreaseStart, double endDamage, double damageDecreaseEnd, double maxDistance)
    {
        public double StartDamage { get; set; } = startDamage;
        public double DamageDecreaseStart { get; set; } = damageDecreaseStart;
        public double EndDamage { get; set; } = endDamage;
        public double DamageDecreaseEnd { get; set; } = damageDecreaseEnd;
        public double MaxDistance { get; set; } = maxDistance;
    }
}
