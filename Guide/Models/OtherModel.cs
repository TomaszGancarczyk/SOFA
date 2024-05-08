using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Channels;
using Guide.Services;
using Microsoft.IdentityModel.Tokens;

namespace Guide.Models
{
    public class OtherModel : IItem
    {
        public List<OtherModel> GetAllOthers(string databasePath)
        {
            List<OtherModel> others = [];
            foreach (string file in Directory.EnumerateFiles($"{databasePath}items\\other", "*.*", SearchOption.TopDirectoryOnly))
            {
                string jsonString = Shared.Reader(file);
                var jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\other\\{objectId}.png");
                if (ifImageExists)
                {
                    OtherModel otherModel = new(jObject);
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
                var jObject = JsonConvert.DeserializeObject(jsonString) as JObject;
                string? objectId = jObject["id"].Value<string>();
                bool ifImageExists = false;
                if (objectId != null)
                    ifImageExists = File.Exists($"{databasePath}icons\\other\\skins\\{objectId}.png");
                if (ifImageExists)
                {
                    OtherModel otherModel = new(jObject);
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
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
