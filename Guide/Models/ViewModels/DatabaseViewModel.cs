using Guide.Models;
using Newtonsoft.Json.Linq;

namespace Guide.Models.ViewModels
{
    public class DatabaseViewModel(List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armors, List<WeaponModel> weapons, List<AttachmentModel> attachments, List<BulletModel> bullets, List<GrenadeModel> grenades, List<MedicineModel> medicines, List<OtherModel> others)
    {
        public List<ArtefactModel> Artefacts { get; set; } = artefacts;
        public List<ContainerModel> Containers { get; set; } = containers;
        public List<ArmorModel> Armors { get; set; } = armors;
        public List<WeaponModel> Weapons { get; set; } = weapons;
        public List<AttachmentModel> Attachments { get; set; } = attachments;
        public List<BulletModel> Bullets { get; set; } = bullets;
        public List<GrenadeModel> Grenades { get; set; } = grenades;
        public List<MedicineModel> Medicines { get; set; } = medicines;
        public List<OtherModel> Barters { get; set; } = others.Where(p => p.Class == "Barter").DistinctBy(p => p.Name).ToList();
        public List<OtherModel> Paints { get; set; } = others.Where(p => p.Class == "Skins and Paint").DistinctBy(p => p.Name).ToList();
        public List<OtherModel> Others { get; set; } = others.Where(p => p.Class == "Other").Where(p => p.Rarity == null || p.Obtained == null || p.Description == null).DistinctBy(p => p.Name).ToList();
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
    public class GrenadeViewModel(string grenadeId, List<GrenadeModel> grenades)
    {
        public GrenadeModel Grenade { get; set; } = grenades.Where(grenade => grenade.Id == grenadeId).FirstOrDefault();
    }
    public class MedicineViewModel(string medicineId, List<MedicineModel> medicines)
    {
        public MedicineModel Medicine { get; set; } = medicines.Where(medicine => medicine.Id == medicineId).FirstOrDefault();
    }
    public class BarterViewModel(string barterId, List<OtherModel> barters)
    {
        public OtherModel Barter { get; set; } = barters.Where(barter => barter.Id == barterId).FirstOrDefault();
    }
    public class PaintViewModel(string paintId, List<OtherModel> paints)
    {
        public OtherModel Paint { get; set; } = paints.Where(paint => paint.Id == paintId).FirstOrDefault();
    }
    public class OtherViewModel(string otherId, List<OtherModel> others)
    {
        public OtherModel Other { get; set; } = others.Where(other => other.Id == otherId).FirstOrDefault();
    }
}
