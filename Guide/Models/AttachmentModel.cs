﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Channels;
using Microsoft.IdentityModel.Tokens;
using Guide.Services;

namespace Guide.Models
{
    public class AttachmentModel : IItem
    {
        public List<AttachmentModel> AllAttachments { get; set; }
        public List<AttachmentModel> GetAllAttachments()
        {
            AllAttachments =
                [
                    .. CreateAttachmentCategory("barrel"),
                    .. CreateAttachmentCategory("collimator_sights"),
                    .. CreateAttachmentCategory("forend"),
                    .. CreateAttachmentCategory("mag"),
                    .. CreateAttachmentCategory("other"),
                    .. CreateAttachmentCategory("pistol_handle")
                ];
            return AllAttachments;
        }
        public List<AttachmentModel> CreateAttachmentCategory(string category)
        {
            string databasePath = Shared.GetEuDatabasePath();
            List<AttachmentModel> attachments = [];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\attachment\\{category}", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                var jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\attachment\\{category}\\{objectId}.png");
                if (ifImageExists)
                {
                    AttachmentModel attachmentModel = new(jObject);
                    attachments.Add(attachmentModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {objectId} doesn't exist");
                }
            }
            return attachments;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        public AttachmentModel() { }
        public AttachmentModel(JObject jObject)
        {
            //id
            Id = jObject["id"]
                .Value<string>();
            //name
            Name = jObject["name"]
                .Value<JObject>("lines")
                .Value<string>("en");
            //check if has rarity
            int ifHasRarity = 1;
            if (jObject["infoBlocks"][0]
                    .Value<JArray>("elements")[1]
                    .Value<string>("type") == "numeric")
                ifHasRarity = 0;
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
                .Value<JArray>("elements")[ifHasRarity]
                .Value<JObject>("value")
                .Value<JObject>("lines")
                .Value<string>("en");
            //check if object is silencer
            int isSielencer = 0;
            if (jObject["infoBlocks"][3].Value<string>("type") == "text" && Class == "Muzzles and Silencers")
            {
                isSielencer = 1;
            }
            //check if object is scope
            int isScope = 0;
            if (Class == "Sights")
            {
                isScope = 2;
            }
            //weight
            Weight = jObject["infoBlocks"][0]
                .Value<JArray>("elements")[1 + ifHasRarity]
                .Value<double>("value");
            //stats
            Dictionary<string, string> stats = [];
            List<string> attachmentAmmoType = [];
            var jsonStats = jObject["infoBlocks"][2]
                .Value<JArray>("elements");
            foreach (var stat in jsonStats)
            {
                //attachment ammo type
                if (stat.Value<string>("type") == "text")
                {
                    if (stat
                    .Value<JObject>("text")
                    .Value<JObject>("lines")
                    .Value<string>("en") != "Suitable ammo")
                    {
                        attachmentAmmoType.Add(stat
                        .Value<JObject>("text")
                        .Value<JObject>("lines")
                        .Value<string>("en"));
                    }
                }
                else if (stat.Value<string>("type") == "key-value")
                {
                    stats.Add(
                    stat
                        .Value<JObject>("key")
                        .Value<JObject>("lines")
                        .Value<string>("en"),
                    stat
                        .Value<JObject>("value")
                        .Value<string>("text"));
                }
                else
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
            }
            if (isScope == 2)
            {
                var additionalStats = jObject["infoBlocks"][3]
                .Value<JArray>("elements");
                if (!additionalStats.IsNullOrEmpty())
                {
                    foreach (var stat in additionalStats)
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
                }
            }
            Stats = stats;
            AttachmentAmmoType = attachmentAmmoType.Distinct().ToList();
            //features
            List<string> features = [];
            if (isSielencer == 1)
            {
                features.Add(jObject["infoBlocks"][3]
                    .Value<JObject>("text")
                    .Value<JObject>("lines")
                    .Value<string>("en"));
            }
            Features = features;
            //suitable for
            List<string> suitableFor = [];
            var jsonSuitableFor = jObject["infoBlocks"].LastOrDefault()
                .Value<JArray>("elements");
            foreach (JToken item in jsonSuitableFor)
            {
                suitableFor.Add(item
                            .Value<JObject>("name")
                            .Value<JObject>("lines")
                            .Value<string>("en"));
            }
            SuitableFor = suitableFor;
            //description
            if (jObject["infoBlocks"][jObject["infoBlocks"].Count() - 2].Value<string>("type") == "text")
            {
                string description = "";
                var descriptionList = jObject["infoBlocks"][jObject["infoBlocks"].Count() - 2]
                                .Value<JObject>("text")
                                .Value<JObject>("lines")
                                .Value<string>("en").Split("@");
                if (!descriptionList.LastOrDefault().StartsWith("Model:") && !descriptionList.LastOrDefault().StartsWith("Reticle:") && !descriptionList.LastOrDefault().StartsWith("ATTENTION:"))
                {
                    description = descriptionList.LastOrDefault();
                }
                Description = description;
            }
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
        public List<string> Features { get; set; }
        public List<string> SuitableFor { get; set; }
        public List<string> AttachmentAmmoType { get; set; }
        public double StartDamage { get; set; }
        public double DamageDecreaseStart { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
}
