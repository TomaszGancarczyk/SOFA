using Guide.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Guide.Models
{
    public class BarterModel
    {
        public static BarterModel GetBarter(string databasePath)
        {
            BarterModel model = new BarterModel();
            string file = $"{databasePath}barter_recipes.json";
            string jsonString = Shared.Reader(file);
            var jObject = JsonConvert.DeserializeObject(jsonString) as JArray;

            List<BarterBaseModel> baseList = [];
            foreach (var barterBase in jObject)
            {
                //bases
                BarterBaseModel baseModel = new()
                {
                    BaseName = barterBase
                    .Value<JObject>("settlementTitle")
                    .Value<JObject>("lines")
                    .Value<string>("en")
                };
                List<BarterBarterModel> barterList = [];
                foreach (var barter in barterBase.Value<JToken>("recipes"))
                {
                    //barters
                    BarterBarterModel barterModel = new()
                    {
                        RequiredLevel = barter
                        .Value<string>("settlementRequiredLevel"),
                        ItemId = barter
                        .Value<string>("item")
                    };

                    //recipes
                    var barters = barter
                        .Value<JArray>("offers");
                    List<OffersBarterModel> offerList = [];
                    foreach (var offer in barters)
                    {
                        OffersBarterModel offerModel = new()
                        {
                            Price = offer.Value<string>("cost")
                        };
                        Dictionary<string, string> requiredItemsList = [];
                        foreach (var item in offer.Value<JArray>("requiredItems"))
                        {
                            string itemId = item.Value<string>("item");
                            string amount = item.Value<string>("amount");
                            requiredItemsList.Add(itemId, amount);
                        }
                        offerModel.RequiredItems = requiredItemsList;
                        offerList.Add(offerModel);
                    }
                    barterModel.Offers = offerList;
                    barterList.Add(barterModel);
                }
                baseModel.Barters = barterList;
                baseList.Add(baseModel);
            }
            model.Bases = baseList;
            return model;
        }

        public List<BarterBaseModel> Bases { get; set; }
    }
    public class BarterBaseModel
    {
        public string BaseName { get; set; }
        public List<BarterBarterModel> Barters { get; set; }
    }
    public class BarterBarterModel
    {
        public string RequiredLevel { get; set; }
        public string ItemId { get; set; }
        public List<OffersBarterModel> Offers { get; set; }
    }
    public class OffersBarterModel
    {
        public string Price { get; set; }
        public Dictionary<string, string> RequiredItems { get; set; }
    }
}
