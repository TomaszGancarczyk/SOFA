using Guide.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Guide.Models
{
    public class BarterModel
    {
        public void GetBarter(string databasePath)
        {
            string file = $"{databasePath}barter_recipes.json";
            string jsonString = Shared.Reader(file);
            var jObject = JsonConvert.DeserializeObject(jsonString) as JArray;

            List<BarterBaseModel> baseList = [];
            foreach (var barterBase in jObject)
            {
                BarterBaseModel baseModel = new();
                baseModel.BaseName = barterBase
                    .Value<JObject>("settlementTitle")
                    .Value<JObject>("lines")
                    .Value<string>("en");
                List<OfferBarterModel> offersList = new();
                foreach (var offer in barterBase.Value<JToken>("recipes"))
                {
                    //offers
                    OfferBarterModel offersModel = new();
                    offersModel.RequiredLevel = offer
                        .Value<string>("settlementRequiredLevel");
                    offersModel.ItemId = offer
                        .Value<string>("item");
                    var offers = offer
                        .Value<JArray>("offers");

                    //recipes
                    List<RecipesBarterModel> recipeList = [];
                    foreach (var recipe in offers)
                    {
                        RecipesBarterModel recipeModel = new();
                        recipeModel.Price = recipe.Value<string>("cost");
                        Dictionary<string, string> requiredItemsList = [];
                        foreach (var item in recipe.Value<JArray>("requiredItems"))
                        {
                            string itemId = item.Value<string>("item");
                            string amount = item.Value<string>("amount");
                            requiredItemsList.Add(itemId, amount);
                        }
                        recipeModel.RequiredItems = requiredItemsList;
                        recipeList.Add(recipeModel);
                    }
                    offersModel.Recipes = recipeList;
                    offersList.Add(offersModel);
                }
                baseModel.Offers = offersList;
                baseList.Add(baseModel);
            }
            Bases = baseList;
        }

        public List<BarterBaseModel> Bases { get; set; }
    }
    public class BarterBaseModel
    {
        public string BaseName { get; set; }
        public List<OfferBarterModel> Offers { get; set; }
    }
    public class OfferBarterModel
    {
        public string RequiredLevel { get; set; }
        public string ItemId { get; set; }
        public List<RecipesBarterModel> Recipes { get; set; }
    }
    public class RecipesBarterModel
    {
        public string Price { get; set; }
        public Dictionary<string, string> RequiredItems { get; set; }
    }
}
