using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Guide.Models
{
    public class WeaponModel : IItem
    {
        public List<WeaponModel> AllWeapons { get; set; }
        public List<WeaponModel> GetAllWeapons()
        {
            AllWeapons =
                [
                    .. CreateArmorCategory("assault_rifle"),
                    .. CreateArmorCategory("device"),
                    .. CreateArmorCategory("heavy"),
                    .. CreateArmorCategory("machine_gun"),
                    .. CreateArmorCategory("melee"),
                    .. CreateArmorCategory("pistol"),
                    .. CreateArmorCategory("shotgun_rifle"),
                    .. CreateArmorCategory("sniper_rifle"),
                    .. CreateArmorCategory("submachine_gun"),
                ];
            return AllWeapons;
        }

        public List<WeaponModel> CreateArmorCategory(string category)
        {
            List<WeaponModel> weapons = [];
            foreach (string file in Directory.EnumerateFiles($"C:\\Users\\a\\Desktop\\SOFA\\Guide\\Guide\\Database\\items\\weapon\\{category}", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = new Json().Reader(file);
                var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/{jObject["category"]}/{jObject["id"].Value<string>()}.png");
                request.Method = "HEAD";
                try
                {
                    request.GetResponse();
                    WeaponModel weaponModel = new(jsonString);
                    weapons.Add(weaponModel);
                }
                catch { }
            }
            return weapons;
        }

        public WeaponModel() { }
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        public WeaponModel(string jsonString)
        {
            //define jobject
            var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
            //check if has rarity
            int ifHaveRarity = 0;
            if (jObject["infoBlocks"][0]
            .Value<string>("type") == "list")
            {
                ifHaveRarity = 1;
            }
            //id
            Id = jObject["id"]
                .Value<string>();
            //name
            Name = jObject["name"]
            .Value<JObject>("lines")
            .Value<string>("en");
            //rarity
            if (ifHaveRarity == 1)
            {
                Rarity = jObject["infoBlocks"][0]
                    .Value<JArray>("elements")[0]
                    .Value<JObject>("value")
                    .Value<JObject>("lines")
                    .Value<string>("en");
            }
            else Rarity = "";
            //class
            Class = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[0 + ifHaveRarity]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            //weight
            Weight = jObject["infoBlocks"][0]
            .Value<JArray>("elements")[2]
            .Value<double>("value");
            //check if object is device
            bool isDevice = false;
            if (Class == "Devices")
            {
                isDevice = true;
            }
            //stats
            Dictionary<string, double> stats = [];
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
                    .Value<double>("en"));
                }
                else if (stat.Value<string>("type") == "text")
                {
                    features.Add(
                        stat
                    .Value<JObject>("text")
                    .Value<JObject>("lines")
                    .Value<string>("en"));
                }
                else
                {
                    stats.Add(
                    stat
                    .Value<JObject>("name")
                    .Value<JObject>("lines")
                    .Value<string>("en"),
                    stat
                    .Value<double>("value"));
                }
            }
            if (!isDevice)
                Stats = stats;
            else
            {
                List<string> featuresToAdd = [];
                foreach (var feature in features) featuresToAdd.Add(feature);
                Features = featuresToAdd;
            }
            //damage modifier
            if (!isDevice)
            {
                List<string> damageModifiers = new List<string>();
                var jsonModifiers = jObject["infoBlocks"][4]
                .Value<JArray>("elements");
                if (jsonModifiers != null)
                {
                    foreach (var modifier in jsonModifiers)
                    {
                        if (modifier.Value<String>("type") == "numeric")
                        {
                            damageModifiers.Add($"{modifier
                                .Value<JObject>("name")
                        .Value<JObject>("lines")
                        .Value<string>("en")}: {modifier
                                .Value<JObject>("formatted")
                        .Value<JObject>("value")
                        .Value<string>("en")}"

                                );
                        }
                        else
                        {
                            damageModifiers.Add(modifier
                                .Value<JObject>("text")
                                .Value<JObject>("lines")
                                .Value<string>("en"));
                        }
                        DamageModifiers = damageModifiers;
                    }
                    //features
                    var jsonFeatures = jObject["infoBlocks"][5]
                         .Value<JArray>("elements");
                    List<string> featuresToAdd = [];
                    if (jsonFeatures.Count() > 0)
                    {
                        foreach (JObject feature in jsonFeatures)
                        {
                            featuresToAdd.Add(feature
                                .Value<JObject>("text")
                                .Value<JObject>("lines")
                                .Value<string>("en"));
                        }
                    }
                    Features = featuresToAdd;
                    //damage graph
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
                    //description
                    Description = jObject["infoBlocks"][7]
                    .Value<JObject>("text")
                    .Value<JObject>("lines")
                    .Value<string>("en");
                }
            }
            else
            {
                DamageModifiers = null;
                //stats
                jsonStats = jObject["infoBlocks"][4]
                         .Value<JArray>("elements");
                foreach (var stat in jsonStats)
                {
                    stats.Add(stat
                    .Value<JObject>("name")
                        .Value<JObject>("lines")
                        .Value<string>("en"),
                     double.Parse(stat
                    .Value<JObject>("formatted")
                        .Value<JObject>("value")
                        .Value<string>("en")
                        .Split()[0]));
                }
                Stats = stats;
                //description
                var Description = jObject["infoBlocks"][5]
                                .Value<JObject>("text")
                                .Value<JObject>("lines")
                                .Value<string>("en");
            }
            //image source
            ImgSource = $"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/{jObject["category"]}/{Id}.png";
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
        public List<string> DamageModifiers { get; set; }
        public List<string> Features { get; set; }
        public Dictionary<string, int> Properties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, double> Stats { get; set; }
        public DamageGraph DamageGraph { get; set; }
        public string CompatibleBackpacks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CompatibleContainers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get; set; }
        public string ImgSource { get; set; }
        public Dictionary<string, Dictionary<double, double>> ArtefactStats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, int> PossibleArtefactStats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class DamageGraph
    {
        public DamageGraph(double startDamage, double damageDecreaseStart, double endDamage, double damageDecreaseEnd, double maxDistance)
        {
            StartDamage = startDamage;
            DamageDecreaseStart = damageDecreaseStart;
            EndDamage = endDamage;
            DamageDecreaseEnd = damageDecreaseEnd;
            MaxDistance = maxDistance;
        }
        public double StartDamage { get; set; }
        public double DamageDecreaseStart { get; set; }
        public double EndDamage { get; set; }
        public double DamageDecreaseEnd { get; set; }
        public double MaxDistance { get; set; }
    }
}
