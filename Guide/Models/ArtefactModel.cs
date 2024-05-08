using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System;
using Microsoft.IdentityModel.Tokens;
using Guide.Services;

namespace Guide.Models
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
                var jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
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
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, Dictionary<double, double>> ArtefactStats { get; set; }
        public Dictionary<string, Dictionary<double, double>> PossibleArtefactStats { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
    }
}
