using Guide.Models;
using Guide.Services;

namespace Guide.Tests
{
    public class DatabaseTest
    {

        List<OtherModel> euOthers = new OtherModel().GetAllOthers(Shared.GetEuDatabasePath()).ToList();
        List<OtherModel> ruOthers = new OtherModel().GetAllOthers(Shared.GetRuDatabasePath()).ToList();

        List<MedicineModel> euMedicines = new MedicineModel().GetAllMedicines(Shared.GetEuDatabasePath()).ToList();
        List<MedicineModel> ruMedicines = new MedicineModel().GetAllMedicines(Shared.GetRuDatabasePath()).ToList();

        List<GrenadeModel> euGrenades = new GrenadeModel().GetAllGrenades(Shared.GetEuDatabasePath()).ToList();
        List<GrenadeModel> ruGrenades = new GrenadeModel().GetAllGrenades(Shared.GetRuDatabasePath()).ToList();

        List<BulletModel> euBullets = new BulletModel().GetAllBullets(Shared.GetEuDatabasePath()).ToList();
        List<BulletModel> ruBullets = new BulletModel().GetAllBullets(Shared.GetRuDatabasePath()).ToList();

        List<AttachmentModel> euAttachments = new AttachmentModel().GetAllAttachments(Shared.GetEuDatabasePath()).ToList();
        List<AttachmentModel> ruAttachments = new AttachmentModel().GetAllAttachments(Shared.GetRuDatabasePath()).ToList();

        List<WeaponModel> euWeapons = new WeaponModel().GetAllWeapons(Shared.GetEuDatabasePath()).ToList();
        List<WeaponModel> ruWeapons = new WeaponModel().GetAllWeapons(Shared.GetRuDatabasePath()).ToList();

        List<ArtefactModel> euArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetEuDatabasePath()).ToList();
        List<ArtefactModel> ruArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetRuDatabasePath()).ToList();

        List<ContainerModel> euContainers = new ContainerModel().GetAllContainers(Shared.GetEuDatabasePath()).ToList();
        List<ContainerModel> ruContainers = new ContainerModel().GetAllContainers(Shared.GetRuDatabasePath()).ToList();

        List<ArmorModel> euArmors = new ArmorModel().GetAllArmors(Shared.GetEuDatabasePath()).ToList();
        List<ArmorModel> ruArmors = new ArmorModel().GetAllArmors(Shared.GetRuDatabasePath()).ToList();

        [Fact]
        public void AllEuClassesSupportedTest()
        {
            List<string> classes = [];
            List<string> databaseClasses = [
                "Skins and Paint", "Barter",
                "Medicine",
                "Grenades",
                "Rounds",
                "Muzzles and Silencers", "Sights", "Hanguards and Brackets", "Magazines", "Other Attachments", "Pistol Grips",
                "Assault Rifles", "Devices", "Other Weapons", "Machine Guns", "Melee Weapons", "Pistols", "Shotguns and Rifles", "Sniper Rifles", "Submachine Guns", "Other",
                "Biochemical", "Electrophysical", "Gravitational", "Thermal",
                "Backpacks and Containers",
                "Clothing", "Combat", "Combo", "Scientist"
                ];
            foreach (var item in euOthers)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in euMedicines)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in euGrenades)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in euBullets)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in euAttachments)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in euWeapons)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in euArtefacts)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in euContainers)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in euArmors)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            Assert.Empty(classes);
        }
        [Fact]
        public void AllRuClassesSupportedTest()
        {
            List<string> classes = [];
            List<string> databaseClasses = [
                "Skins and Paint", "Barter",
                "Medicine",
                "Grenades",
                "Rounds",
                "Muzzles and Silencers", "Sights", "Hanguards and Brackets", "Magazines", "Other Attachments", "Pistol Grips",
                "Assault Rifles", "Devices", "Other Weapons", "Machine Guns", "Melee Weapons", "Pistols", "Shotguns and Rifles", "Sniper Rifles", "Submachine Guns", "Other",
                "Biochemical", "Electrophysical", "Gravitational", "Thermal",
                "Backpacks and Containers",
                "Clothing", "Combat", "Combo", "Scientist"
                ];
            foreach (var item in ruOthers)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in ruMedicines)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in ruGrenades)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in ruBullets)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in ruAttachments)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in ruWeapons)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in ruArtefacts)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in ruContainers)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            foreach (var item in ruArmors)
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                    classes.Add(item.Class);
            Assert.Empty(classes);
        }

        [Fact]
        public void AllEuFilesAreJsonTest()
        {
            foreach (string file in Directory.EnumerateFiles($"{Shared.GetEuDatabasePath()}\\items\\", "*.*"))
            {
                Assert.Contains(".json", file);
            }
        }
        [Fact]
        public void AllRuFilesAreJsonTest()
        {
            foreach (string file in Directory.EnumerateFiles($"{Shared.GetRuDatabasePath()}\\items\\", "*.*"))
            {
                Assert.Contains(".json", file);
            }
        }

        [Fact]
        public void AllEuItemsHaveId()
        {
            foreach (var item in euOthers) Assert.NotEmpty(item.Id);
            foreach (var item in euMedicines) Assert.NotEmpty(item.Id);
            foreach (var item in euGrenades) Assert.NotEmpty(item.Id);
            foreach (var item in euBullets) Assert.NotEmpty(item.Id);
            foreach (var item in euAttachments) Assert.NotEmpty(item.Id);
            foreach (var item in euWeapons) Assert.NotEmpty(item.Id);
            foreach (var item in euArtefacts) Assert.NotEmpty(item.Id);
            foreach (var item in euContainers) Assert.NotEmpty(item.Id);
            foreach (var item in euArmors) Assert.NotEmpty(item.Id);
        }
        [Fact]
        public void AllRuItemsHaveId()
        {
            foreach (var item in ruOthers) Assert.NotEmpty(item.Id);
            foreach (var item in ruMedicines) Assert.NotEmpty(item.Id);
            foreach (var item in ruGrenades) Assert.NotEmpty(item.Id);
            foreach (var item in ruBullets) Assert.NotEmpty(item.Id);
            foreach (var item in ruAttachments) Assert.NotEmpty(item.Id);
            foreach (var item in ruWeapons) Assert.NotEmpty(item.Id);
            foreach (var item in ruArtefacts) Assert.NotEmpty(item.Id);
            foreach (var item in ruContainers) Assert.NotEmpty(item.Id);
            foreach (var item in ruArmors) Assert.NotEmpty(item.Id);
        }

        [Fact]
        public void AllEuItemsHaveImg()
        {
            foreach (var item in euOthers) Assert.NotEmpty(item.ImgSource);
            foreach (var item in euMedicines) Assert.NotEmpty(item.ImgSource);
            foreach (var item in euGrenades) Assert.NotEmpty(item.ImgSource);
            foreach (var item in euBullets) Assert.NotEmpty(item.ImgSource);
            foreach (var item in euAttachments) Assert.NotEmpty(item.ImgSource);
            foreach (var item in euWeapons) Assert.NotEmpty(item.ImgSource);
            foreach (var item in euArtefacts) Assert.NotEmpty(item.ImgSource);
            foreach (var item in euContainers) Assert.NotEmpty(item.ImgSource);
            foreach (var item in euArmors) Assert.NotEmpty(item.ImgSource);
        }
        [Fact]
        public void AllRuItemsHaveImg()
        {
            foreach (var item in ruOthers) Assert.NotEmpty(item.ImgSource);
            foreach (var item in ruMedicines) Assert.NotEmpty(item.ImgSource);
            foreach (var item in ruGrenades) Assert.NotEmpty(item.ImgSource);
            foreach (var item in ruBullets) Assert.NotEmpty(item.ImgSource);
            foreach (var item in ruAttachments) Assert.NotEmpty(item.ImgSource);
            foreach (var item in ruWeapons) Assert.NotEmpty(item.ImgSource);
            foreach (var item in ruArtefacts) Assert.NotEmpty(item.ImgSource);
            foreach (var item in ruContainers) Assert.NotEmpty(item.ImgSource);
            foreach (var item in ruArmors) Assert.NotEmpty(item.ImgSource);
        }

        [Fact]
        public void AllEuItemsHaveName()
        {
            foreach (var item in euOthers) Assert.NotEmpty(item.Name);
            foreach (var item in euMedicines) Assert.NotEmpty(item.Name);
            foreach (var item in euGrenades) Assert.NotEmpty(item.Name);
            foreach (var item in euBullets) Assert.NotEmpty(item.Name);
            foreach (var item in euAttachments) Assert.NotEmpty(item.Name);
            foreach (var item in euWeapons) Assert.NotEmpty(item.Name);
            foreach (var item in euArtefacts) Assert.NotEmpty(item.Name);
            foreach (var item in euContainers) Assert.NotEmpty(item.Name);
            foreach (var item in euArmors) Assert.NotEmpty(item.Name);
        }
        [Fact]
        public void AllRuItemsHaveName()
        {
            foreach (var item in ruOthers) Assert.NotEmpty(item.Name);
            foreach (var item in ruMedicines) Assert.NotEmpty(item.Name);
            foreach (var item in ruGrenades) Assert.NotEmpty(item.Name);
            foreach (var item in ruBullets) Assert.NotEmpty(item.Name);
            foreach (var item in ruAttachments) Assert.NotEmpty(item.Name);
            foreach (var item in ruWeapons) Assert.NotEmpty(item.Name);
            foreach (var item in ruArtefacts) Assert.NotEmpty(item.Name);
            foreach (var item in ruContainers) Assert.NotEmpty(item.Name);
            foreach (var item in ruArmors) Assert.NotEmpty(item.Name);
        }

        [Fact]
        public void AllEuClassesSucesfullyMovedToAllItems()
        {
            List<Item> allEuItems = [];
            foreach (var item in euOthers) allEuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in euMedicines) allEuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in euGrenades) allEuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in euBullets) allEuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in euAttachments) allEuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in euWeapons) allEuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in euArtefacts) allEuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in euContainers) allEuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in euArmors) allEuItems.Add(Shared.CreateItemFromModel(item));

            Assert.Equal(allEuItems.Count, euOthers.Count + euMedicines.Count + euGrenades.Count + euBullets.Count + euAttachments.Count + euWeapons.Count + euArtefacts.Count + euContainers.Count + euArmors.Count);
        }
        [Fact]
        public void AllRuClassesSucesfullyMovedToAllItems()
        {
            List<Item> allRuItems = [];
            foreach (var item in ruOthers) allRuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in ruMedicines) allRuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in ruGrenades) allRuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in ruBullets) allRuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in ruAttachments) allRuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in ruWeapons) allRuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in ruArtefacts) allRuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in ruContainers) allRuItems.Add(Shared.CreateItemFromModel(item));
            foreach (var item in ruArmors) allRuItems.Add(Shared.CreateItemFromModel(item));

            Assert.Equal(allRuItems.Count, ruOthers.Count + ruMedicines.Count + ruGrenades.Count + ruBullets.Count + ruAttachments.Count + ruWeapons.Count + ruArtefacts.Count + ruContainers.Count + ruArmors.Count);
        }
    }
}