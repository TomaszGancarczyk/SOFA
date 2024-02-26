namespace Guide.Models.ViewModels
{
    public class DatabaseViewModel(List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armors, List<WeaponModel> weapons, List<AttachmentModel> attachments, List<BulletModel> bullets)
    {
        public List<ArtefactModel> Artefacts { get; set; } = artefacts;
        public List<ContainerModel> Containers { get; set; } = containers;
        public List<ArmorModel> Armors { get; set; } = armors;
        public List<WeaponModel> Weapons { get; set; } = weapons;
        public List<AttachmentModel> Attachments { get; set; } = attachments;
        public List<BulletModel> Bullets { get; set; } = bullets;
    }
    public class WeaponViewModel(string weaponId, List<WeaponModel> weapons)
    {
        public WeaponModel Weapon { get; set; } = weapons.Where(weapon => weapon.Id == weaponId).FirstOrDefault();
    }
    public class ArmorViewModel(string armorId, List<ArmorModel> armors)
    {
        public ArmorModel Armor { get; set; } = armors.Where(armor => armor.Id == armorId).FirstOrDefault();
    }
    public class ArtefactViewModel(string artefactId, List<ArtefactModel> artefacts)
    {
        public ArtefactModel Artefact { get; set; } = artefacts.Where(artefactt => artefactt.Id == artefactId).FirstOrDefault();
    }
    public class ContainerViewModel(string containerId, List<ContainerModel> containers)
    {
        public ContainerModel Container { get; set; } = containers.Where(container => container.Id == containerId).FirstOrDefault();
    }
    public class AttachmentViewModel(string attachmentId, List<AttachmentModel> attachments)
    {
        public AttachmentModel Attachment { get; set; } = attachments.Where(attachment => attachment.Id == attachmentId).FirstOrDefault();
    }
    public class BulletViewModel(string bulletId, List<BulletModel> bullets)
    {
        public BulletModel Bullet { get; set; } = bullets.Where(bullet => bullet.Id == bulletId).FirstOrDefault();
    }
}
