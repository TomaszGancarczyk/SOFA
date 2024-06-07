﻿using Guide.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Guide.Models.DatabaseModels
{
    public class ArtefactModel : IItem
    {
        public List<ArtefactModel> AllArtefacts { get; set; }
        public List<ArtefactModel> GetAllArtefacts(string databasePath)
        {
            AllArtefacts =
                [
                    .. CreateArtefactsCategory("biochemical", databasePath),
                    .. CreateArtefactsCategory("electrophysical", databasePath),
                    .. CreateArtefactsCategory("gravity", databasePath),
                    .. CreateArtefactsCategory("thermal", databasePath),
                ];
            return AllArtefacts;
        }

        public List<ArtefactModel> CreateArtefactsCategory(string category, string databasePath)
        {
            List<ArtefactModel> artefacts = [];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\artefact\\{category}", "*.*", SearchOption.TopDirectoryOnly))
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
                    ifImageExists = File.Exists($"{databasePath}icons\\artefact\\{category}\\{objectId}.png");
                if (ifImageExists)
                {
                    ArtefactModel artefactsModel = new(jObject);
                    artefacts.Add(artefactsModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {objectId} doesn't exist");
                }
            }
            return artefacts;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public ArtefactModel() { }
        public ArtefactModel(JObject jObject)
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
            Dictionary<string, Dictionary<double, double>> stats = [];
            var jsonStats = jObject["infoBlocks"][4]
                .Value<JArray>("elements");
            foreach (var stat in jsonStats)
            {
                Dictionary<double, double> range = [];
                if (stat.Value<string>("type") == "text")
                {
                    range.Add(0, 0);
                    stats.Add(
                        stat
                        .Value<JObject>("text")
                        .Value<JObject>("lines")
                        .Value<string>("en"),
                            range
                        );
                }
                else
                {
                    range.Add(
                        stat
                        .Value<double>("min"),
                        stat
                        .Value<double>("max")
                    );
                    stats.Add(
                        stat
                        .Value<JObject>("name")
                        .Value<JObject>("lines")
                        .Value<string>("en"),
                            range
                        );
                }
            };
            ArtefactStats = stats;
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
        public string Class { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, Dictionary<double, double>> ArtefactStats { get; set; }
        public Dictionary<string, Dictionary<double, double>> PossibleArtefactStats { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
        string IItem.Rarity { get => null; set => throw new NotImplementedException(); }
        List<string> IItem.Features { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, int> IItem.Properties { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, string> IItem.Stats { get => null; set => throw new NotImplementedException(); }
        ItemBarter IItem.Barter { get => null; set => throw new NotImplementedException(); }
        Dictionary<int, Dictionary<string, string>> IItem.UpgradeStats { get => null; set => throw new NotImplementedException(); }
        WeaponModel.DamageGraph IItem.DamageGraphField { get => null; set => throw new NotImplementedException(); }
        string IItem.CompatibleBackpacks { get => null; set => throw new NotImplementedException(); }
        string IItem.CompatibleContainers { get => null; set => throw new NotImplementedException(); }
        List<string> IItem.SuitableFor { get => null; set => throw new NotImplementedException(); }
        List<string> IItem.AttachmentAmmoType { get => null; set => throw new NotImplementedException(); }
        string IItem.Obtained { get => null; set => throw new NotImplementedException(); }
    }
}