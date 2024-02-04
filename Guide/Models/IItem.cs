namespace Guide.Models
{
    public interface IItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string ImgSource { get; set; }
    }
}
