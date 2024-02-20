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
    public class ArmorViewModel
    {
        public ArmorModel CurrentArmor { get; set; }
        public ArmorViewModel(string armorId, List<ArmorModel> armors)
        {
            CurrentArmor = armors.Where(armor => armor.Id == armorId).FirstOrDefault();
        }
    }
    public class ArtefactViewModel
    {
        public ArtefactModel CurrentArtefact { get; set; }
        public ArtefactViewModel(string artefactId, List<ArtefactModel> artefacts)
        {
            CurrentArtefact = artefacts.Where(artefactt => artefactt.Id == artefactId).FirstOrDefault();
        }
    }
    public class ContainerViewModel
    {
        public ContainerModel CurrentContainer { get; set; }
        public ContainerViewModel(string containerId, List<ContainerModel> containers)
        {
            CurrentContainer = containers.Where(container => container.Id == containerId).FirstOrDefault();
        }
    }
}
