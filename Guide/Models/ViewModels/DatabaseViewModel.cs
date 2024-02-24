namespace Guide.Models.ViewModels
{
    public class DatabaseViewModel
    {
        public List<ArtefactModel> Artefacts { get; set; }
        public List<ContainerModel> Containers { get; set; }
        public List<ArmorModel> Armors { get; set; }
        public List<WeaponModel> Weapons { get; set; }
        public List<AttachmentModel> Attachments { get; set; }
        public DatabaseViewModel(List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armors, List<WeaponModel> weapons, List<AttachmentModel> attachments)
        {
            Artefacts = artefacts;
            Containers = containers;
            Armors = armors;
            Weapons = weapons;
            Attachments = attachments;
        }
    }
    public class WeaponViewModel
    {
        public WeaponModel CurrentWeapon { get; set; }
        public WeaponViewModel(string weaponId, List<WeaponModel> weapons)
        {
            CurrentWeapon = weapons.Where(weapon => weapon.Id == weaponId).FirstOrDefault();
        }
    }
    public class ArmorViewModel
    {
        public ArmorModel Armor { get; set; }
        public ArmorViewModel(string armorId, List<ArmorModel> armors)
        {
            Armor = armors.Where(armor => armor.Id == armorId).FirstOrDefault();
        }
    }
    public class ArtefactViewModel
    {
        public ArtefactModel Artefact { get; set; }
        public ArtefactViewModel(string artefactId, List<ArtefactModel> artefacts)
        {
            Artefact = artefacts.Where(artefactt => artefactt.Id == artefactId).FirstOrDefault();
        }
    }
    public class ContainerViewModel
    {
        public ContainerModel Container { get; set; }
        public ContainerViewModel(string containerId, List<ContainerModel> containers)
        {
            Container = containers.Where(container => container.Id == containerId).FirstOrDefault();
        }
    }
    public class AttachmentViewModel
    {
        public AttachmentModel Attachment { get; set; }
        public AttachmentViewModel(string attachmentId, List<AttachmentModel> attachments)
        {
            Attachment = attachments.Where(attachment => attachment.Id == attachmentId).FirstOrDefault();
        }
    }
}
