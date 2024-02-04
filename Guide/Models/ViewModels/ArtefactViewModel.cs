namespace Guide.Models.ViewModels
{
    public class ArtefactViewModel
    {
        public List<ArtefactModel> Artefacts { get; set; }
        public List<ContainerModel> Containers { get; set; }
        public ArtefactViewModel(List<ArtefactModel> artefacts, List<ContainerModel> containers)
        {
            Artefacts = artefacts;
            Containers = containers;
        }
    }
}
