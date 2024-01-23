using Guide.Models.Interfaces;

namespace Guide.Models
{
    public class Fence : IBarter
    {
        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public int Tiles { get; set; }
    }
}
