namespace Guide.Models
{
    public class Barter
    {
        public Barter(int cost, Dictionary<IItem, int> barterResources)
        {
            Cost = cost;
            BarterResources = barterResources;
        }
        public int Cost { get; set; }
        public Dictionary<IItem, int> BarterResources { get; set; }
    }
}
