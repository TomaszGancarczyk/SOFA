namespace Guide.Models.ViewModels
{
    public class DatabaseViewModel
    {
        public List<ArtefactModel> Artefacts { get; set; }
        public List<ContainerModel> Containers { get; set; }
        public List<ArmorModel> Armors { get; set; }
        public DatabaseViewModel(List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armors) 
        {
            Artefacts = artefacts;
            Containers = containers;
            Armors = armors;
        }
    }
}
