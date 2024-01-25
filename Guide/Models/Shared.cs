using Microsoft.Identity.Client;

namespace Guide.Models
{
    public class Barter
    {
        public int Cost { get; set; }
        public Dictionary<string, int> Barters { get; set; } = new Dictionary<string, int>();
        public Barter(int cots, Dictionary<string, int> barters)
        {  
            Cost = cots;
            Barters = barters;
        }
    }
    public class Json
    {
        public string Reader()
        {

        }
    }
}
