namespace Guide.Models.Interfaces
{
    public interface IItem : IBarter
    {
        int Id { get; set; }
        string ImgSource { get; set; }
        string Name { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        string Description { get; set; }
    }
}
