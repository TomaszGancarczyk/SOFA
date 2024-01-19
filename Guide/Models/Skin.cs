using Guide.Models.Interfaces;

namespace Guide.Models
{
    public class Skin : IBarter
    {
        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
    }
}
