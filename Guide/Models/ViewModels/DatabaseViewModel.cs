using Guide.Models.DatabaseModels;

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
    public class ItemViewModel(Item item)
    {
        public Item Item { get; set; } = item;
    }
}
