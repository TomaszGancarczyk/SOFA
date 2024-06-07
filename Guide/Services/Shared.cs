using Guide.Models.DatabaseModels;

namespace Guide.Services
{
    public class Shared
    {
        public static string GetEuDatabasePath()
        {
            return "C:\\Users\\a\\Desktop\\SOFA\\Guide\\Guide\\Database\\stalcraft-database\\global\\";
        }
        public static string GetRuDatabasePath()
        {
            return "C:\\Users\\a\\Desktop\\SOFA\\Guide\\Guide\\Database\\stalcraft-database\\ru\\";
        }
        public static string Reader(string filePath)
        {
            using StreamReader reader = new(filePath);
            string text = reader.ReadToEnd();
            return text;
        }
        public static Item CreateItemFromModel(IItem item)
        {
            return new Item
            {
                Id = item.Id,
                Name = item.Name,
                Rarity = item.Rarity,
                Class = item.Class,
                Weight = item.Weight,
                Features = item.Features,
                Properties = item.Properties,
                Stats = item.Stats,
                Description = item.Description,
                ImgSource = item.ImgSource,
                Barter = item.Barter,
                UpgradeStats = item.UpgradeStats,
                DamageGraphField = item.DamageGraphField,
                CompatibleBackpacks = item.CompatibleBackpacks,
                CompatibleContainers = item.CompatibleContainers,
                ArtefactStats = item.ArtefactStats,
                PossibleArtefactStats = item.PossibleArtefactStats,
                SuitableFor = item.SuitableFor,
                AttachmentAmmoType = item.AttachmentAmmoType,
                Obtained = item.Obtained
            };
        }
    }
}
