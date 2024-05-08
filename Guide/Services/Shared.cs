using Guide.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
    public class Item(string id, string name, string classs) : IItem
    {
        public string Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Class { get; set; } = classs;

        public static List<Item> IItemToItem(IEnumerable<IItem> iItems)
        {
            List<Item> items = [];
            foreach (IItem iItem in iItems)
            {
                var currentItem = new Item(iItem.Id, iItem.Name, iItem.Class);
                items.Add(currentItem);
            }
            return items;
        }
    }
}
