using Guide.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Guide.Models.DatabaseModels
{
    public class ContainerModel : IItem
    {
        public List<ContainerModel> GetAllContainers(string databasePath)
        {
            List<ContainerModel> containers = [];
            BarterModel bases = BarterModel.GetBarter(Shared.GetEuDatabasePath());
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\containers", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                if (JsonConvert.DeserializeObject(jsonString) is not JObject jObject)
                {
                    Console.WriteLine($"Jobject is null for: {file}");
                    continue;
                }
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\containers\\{objectId}.png");
                if (ifImageExists)
                {
                    ContainerModel containerModel = new(jObject);
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
                                containerModel.Barter = barter;
                                factionBase.Barters.Remove(offer);
                                break;
                            }
                        }
                    }
                    containers.Add(containerModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {objectId} doesn't exist");
                }
            }
            return containers;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public ContainerModel() { }
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
#pragma warning disable CS8603 // Possible null reference return.

        public string Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, string> Stats { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
        public ItemBarter Barter { get; set; }
        List<string> IItem.Features { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, int> IItem.Properties { get => null; set => throw new NotImplementedException(); }
        Dictionary<int, Dictionary<string, string>> IItem.UpgradeStats { get => null; set => throw new NotImplementedException(); }
        WeaponModel.DamageGraph IItem.DamageGraphField { get => null; set => throw new NotImplementedException(); }
        string IItem.CompatibleBackpacks { get => null; set => throw new NotImplementedException(); }
        string IItem.CompatibleContainers { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, Dictionary<double, double>> IItem.ArtefactStats { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, Dictionary<double, double>> IItem.PossibleArtefactStats { get => null; set => throw new NotImplementedException(); }
        List<string> IItem.SuitableFor { get => null; set => throw new NotImplementedException(); }
        List<string> IItem.AttachmentAmmoType { get => null; set => throw new NotImplementedException(); }
        string IItem.Obtained { get => null; set => throw new NotImplementedException(); }
    }
}
