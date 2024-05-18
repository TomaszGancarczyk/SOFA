﻿using Guide.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Guide.Models
{
    public class OtherModel : IItem
    {
        public List<OtherModel> GetAllOthers(string databasePath)
        {
            List<OtherModel> others = [];
            BarterModel bases = BarterModel.GetBarter(Shared.GetEuDatabasePath());
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\other", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                JObject jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\other\\{objectId}.png");
                if (ifImageExists)
                {
                    OtherModel otherModel = new(jObject);
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
                                otherModel.Barter = barter;
                                factionBase.Barters.Remove(offer);
                                break;
                            }
                        }
                    }
                    others.Add(otherModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {objectId} doesn't exist");
                }
            }
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\other\\skins", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                JObject jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\other\\skins\\{objectId}.png");
                if (ifImageExists)
                {
                    OtherModel otherModel = new(jObject);
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
                                otherModel.Barter = barter;
                                factionBase.Barters.Remove(offer);
                                break;
                            }
                        }
                    }
                    others.Add(otherModel);
                }
                else
                {
                    Console.WriteLine($"Image for Id: {objectId} doesn't exist");
                }
            }
            return others;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public OtherModel() { }
        public OtherModel(JObject jObject)
        {
            //id
            Id = jObject["id"]
            .Value<string>();
            //name
            Name = jObject["name"]
                .Value<JObject>("lines")
                .Value<string>("en");
            // rarity / class / weight
            if (jObject["infoBlocks"][0].Value<JArray>("elements").Count > 1)
            {
                foreach (var item in jObject["infoBlocks"][0].Value<JArray>("elements"))
                {
                    string? key;
                    if (item.Value<string>("type") == "numeric")
                    {
                        key = item.Value<JObject>("name")
                                  .Value<JObject>("lines")
                                  .Value<string>("en");
                    }
                    else
                    {
                        key = item.Value<JObject>("key")
                                  .Value<JObject>("lines")
                                  .Value<string>("en");
                    }
                    if (key == "Rank")
                    {
                        //rarity
                        Rarity = item
                            .Value<JObject>("value")
                            .Value<JObject>("lines")
                            .Value<string>("en");
                    }
                    else if (key == "Class")
                    {
                        //class
                        Class = item
                            .Value<JObject>("value")
                            .Value<JObject>("lines")
                            .Value<string>("en");
                    }
                    else if (key == "Weight")
                    {
                        //weight
                        Weight = item
                            .Value<double>("value");
                    }
                }
            }
            Class ??= "Skins and Paint";
            //obtained
            if (jObject["infoBlocks"].Count() > 2)
            {
                if (jObject["infoBlocks"][2].Value<string>("type") == "list")
                {
                    if (jObject["infoBlocks"][2].Value<JArray>("elements")[0].Value<JObject>("text").Value<JObject>("lines").Value<string>("en") == "Obtained")
                    {
                        Obtained = jObject["infoBlocks"][2]
                            .Value<JArray>("elements")[1]
                            .Value<JObject>("text")
                            .Value<JObject>("lines")
                            .Value<string>("en");
                    }
                    else
                    {
                    }
                }
            }
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
            //give barter class
            if (Rarity != null && Obtained != null && Description != null) Class = "Barter";
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public string Obtained { get; set; }
        public bool IsPaint { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
        public ItemBarter Barter { get; set; }
        List<string> IItem.Features { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, int> IItem.Properties { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, string> IItem.Stats { get => null; set => throw new NotImplementedException(); }
        Dictionary<int, Dictionary<string, string>> IItem.UpgradeStats { get => null; set => throw new NotImplementedException(); }
        WeaponModel.DamageGraph IItem.DamageGraphField { get => null; set => throw new NotImplementedException(); }
        string IItem.CompatibleBackpacks { get => null; set => throw new NotImplementedException(); }
        string IItem.CompatibleContainers { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, Dictionary<double, double>> IItem.ArtefactStats { get => null; set => throw new NotImplementedException(); }
        Dictionary<string, Dictionary<double, double>> IItem.PossibleArtefactStats { get => null; set => throw new NotImplementedException(); }
        List<string> IItem.SuitableFor { get => null; set => throw new NotImplementedException(); }
        List<string> IItem.AttachmentAmmoType { get => null; set => throw new NotImplementedException(); }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
