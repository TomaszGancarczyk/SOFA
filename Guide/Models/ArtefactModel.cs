using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System;
using Microsoft.IdentityModel.Tokens;

namespace Guide.Models
{
    public class ArtefactModel : IItem
    {
        public List<ArtefactModel> allArtefacts { get; set; }
        public List<ArtefactModel> GetAllArtefacts()
        {
            allArtefacts =
                CreateArtefactsCategory("biochemical")
                .Concat(CreateArtefactsCategory("electrophysical"))
                .Concat(CreateArtefactsCategory("gravity"))
                .Concat(CreateArtefactsCategory("thermal"))
                .ToList();
            return allArtefacts;
        }

        public List<ArtefactModel> CreateArtefactsCategory(string category)
        {
            List<ArtefactModel> artefacts = new List<ArtefactModel>();
            foreach (string file in Directory.EnumerateFiles($"C:\\Users\\a\\Desktop\\SOFA\\Guide\\Guide\\Database\\items\\artefact\\{category}", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = new Json().Reader(file);
                var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/{jObject["category"]}/{jObject["id"].Value<string>()}.png");
                //request.Method = "HEAD";
                //try
                //{
                //    request.GetResponse();
                ArtefactModel artefactsModel = new ArtefactModel(jsonString);
                artefacts.Add(artefactsModel);
                //}
                //catch { }
            }
            return artefacts;
        }
        public ArtefactModel() { }
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        public ArtefactModel(string jsonString)
        {
            //define jobject
            var jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
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
            Dictionary<string, Dictionary<double, double>> stats = new Dictionary<string, Dictionary<double, double>>();
            var jsonStats = jObject["infoBlocks"][4]
                .Value<JArray>("elements");
            foreach (var stat in jsonStats)
            {
                Dictionary<double, double> range = new Dictionary<double, double>();
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
            Stats = stats;
            //description
            var count = jObject["infoBlocks"].Count();
            if (jObject["infoBlocks"].Count() == 6)
            {
                Description = jObject["infoBlocks"][5]
                        .Value<JObject>("text")
                        .Value<JObject>("lines")
                        .Value<string>("en");
            }
            else Description = "";
            //image source
            ImgSource = $"https://raw.githubusercontent.com/EXBO-Studio/stalcraft-database/main/global/icons/{jObject["category"]}/{Id}.png";

            var temp = jObject["infoBlocks"];
        }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.public string Id { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public Dictionary<string, Dictionary<double, double>> Stats { get; set; }
        public Dictionary<string, int> PossibleStats { get; set; }
        public Dictionary<string, string> BarterBase { get; set; }
        public List<Barter> Barters { get; set; }
        public List<string> UsedInID { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
    }
}
