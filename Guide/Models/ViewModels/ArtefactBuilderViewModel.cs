using Guide.Models.DatabaseModels;

namespace Guide.Models.ViewModels
{
    public class ArtefactBuilderViewModel
    {
        public List<ArtefactModel> Artefacts { get; set; }
        public List<ContainerModel> Containers { get; set; }
        public ArtefactBuilderViewModel(List<ArtefactModel> artefacts, List<ContainerModel> containers)
        {
            Artefacts = artefacts;
            Containers = containers;
        }

        public ContainerModel? CurrentContainer = null;
        public List<ArtefactModel>? CurrentArtefacts = null;


        public ArtefactBuilderViewModel(ContainerModel? currentContainer, List<ArtefactModel>? currentArtefacts)
        {
            CurrentContainer = currentContainer;
            CurrentArtefacts = currentArtefacts;
        }
    }
}
