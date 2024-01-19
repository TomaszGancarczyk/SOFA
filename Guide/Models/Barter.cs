using Guide.Models.Interfaces;

namespace Guide.Models
{
    public class Barter
    {
        public Barter(int cost, Dictionary<IBarter, int> barterResources)
        {
            Cost = cost;
            BarterResources = barterResources;
        }
        public int Cost { get; set; }
        public Dictionary<IBarter, int> BarterResources { get; set; }
    }
}
