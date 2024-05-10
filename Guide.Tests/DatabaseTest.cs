using Guide.Models;
using Guide.Services;

namespace Guide.Tests
{
    public class DatabaseTest
    {

        List<OtherModel> euOthers = new OtherModel().GetAllOthers(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
        List<OtherModel> ruOthers = new OtherModel().GetAllOthers(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();

        List<MedicineModel> euMedicines = new MedicineModel().GetAllMedicines(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
        List<MedicineModel> ruMedicines = new MedicineModel().GetAllMedicines(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();

        List<GrenadeModel> euGrenades = new GrenadeModel().GetAllGrenades(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
        List<GrenadeModel> ruGrenades = new GrenadeModel().GetAllGrenades(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();

        List<BulletModel> euBullets = new BulletModel().GetAllBullets(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
        List<BulletModel> ruBullets = new BulletModel().GetAllBullets(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();

        List<AttachmentModel> euAttachments = new AttachmentModel().GetAllAttachments(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
        List<AttachmentModel> ruAttachments = new AttachmentModel().GetAllAttachments(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();

        List<WeaponModel> euWeapons = new WeaponModel().GetAllWeapons(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
        List<WeaponModel> ruWeapons = new WeaponModel().GetAllWeapons(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();

        List<ArtefactModel> euArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
        List<ArtefactModel> ruArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();

        List<ContainerModel> euContainers = new ContainerModel().GetAllContainers(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
        List<ContainerModel> ruContainers = new ContainerModel().GetAllContainers(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();

        List<ArmorModel> euArmors = new ArmorModel().GetAllArmors(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
        List<ArmorModel> ruArmors = new ArmorModel().GetAllArmors(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();

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


    }
}