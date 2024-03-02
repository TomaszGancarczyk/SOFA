using Guide.Models;
using System.Collections.Generic;
using System.Linq;

namespace Guide.Services
{
    public class Shared
    {
        public static string GetDatabasePath()
        {
            return "C:\\Users\\a\\Desktop\\SOFA\\Guide\\Guide\\Database\\stalcraft-database\\global\\";
        }
        public static string Reader(string filePath)
        {
            using StreamReader reader = new(filePath);
            string text = reader.ReadToEnd();
            return text;
        }
    }
    public class Item : IItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public Item()
        {
            
        }
        public Item(string id, string name, string classs)
        {
            Id = id;
            Name = name;
            Class = classs;
        }
        public static List<Item> IItemToItem(IEnumerable<IItem> iItems)
        {
            List<Item> items = new List<Item>();
            foreach (IItem iItem in iItems)
            {
                var currentItem = new Item(iItem.Id, iItem.Name, iItem.Class);
                items.Add(currentItem);
            }
            return items;
        }
    }
}
