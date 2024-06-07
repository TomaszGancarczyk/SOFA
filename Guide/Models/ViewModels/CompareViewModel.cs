using Guide.Models.DatabaseModels;

namespace Guide.Models.ViewModels
{
    public class CompareViewModel(List<Item> items)
    {
        public List<Item> Items { get; set; } = items;
    }
}
