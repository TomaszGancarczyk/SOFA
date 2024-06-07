namespace Guide.Models
{
    public class QuestModel
    {
        public string Id { get; set; }
    }
    public class QuestStep
    {
        public string StepNumber { get; set; }
        public Dictionary<string, string> MapAndCoordinates {  get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
    }
}
