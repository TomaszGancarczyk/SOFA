using Guide.Models;
using Guide.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.Net.Http;

namespace Guide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            List<Item> allEuItems = [];
            List<Item> allRuItems = [];

            List<OtherModel> euOthers = new OtherModel().GetAllOthers(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<OtherModel> ruOthers = new OtherModel().GetAllOthers(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            allEuItems.AddRange(Item.IItemToItem(euOthers));
            allRuItems.AddRange(Item.IItemToItem(ruOthers));
            builder.Services.AddSingleton(euOthers);
            builder.Services.AddSingleton(ruOthers);

            List<MedicineModel> euMedicines = new MedicineModel().GetAllMedicines(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<MedicineModel> ruMedicines = new MedicineModel().GetAllMedicines(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            allEuItems.AddRange(Item.IItemToItem(euMedicines));
            allRuItems.AddRange(Item.IItemToItem(ruMedicines));
            builder.Services.AddSingleton(euMedicines);
            builder.Services.AddSingleton(ruMedicines);

            List<GrenadeModel> euGrenades = new GrenadeModel().GetAllGrenades(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<GrenadeModel> ruGrenades = new GrenadeModel().GetAllGrenades(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            allEuItems.AddRange(Item.IItemToItem(euGrenades));
            allRuItems.AddRange(Item.IItemToItem(ruGrenades));
            builder.Services.AddSingleton(euGrenades);
            builder.Services.AddSingleton(ruGrenades);

            List<BulletModel> euBullets = new BulletModel().GetAllBullets(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<BulletModel> ruBullets = new BulletModel().GetAllBullets(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            allEuItems.AddRange(Item.IItemToItem(euBullets));
            allRuItems.AddRange(Item.IItemToItem(ruBullets));
            builder.Services.AddSingleton(euBullets);
            builder.Services.AddSingleton(ruBullets);

            List<AttachmentModel> euAttachments = new AttachmentModel().GetAllAttachments(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<AttachmentModel> ruAttachments = new AttachmentModel().GetAllAttachments(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            allEuItems.AddRange(Item.IItemToItem(euAttachments));
            allRuItems.AddRange(Item.IItemToItem(ruAttachments));
            builder.Services.AddSingleton(euAttachments);
            builder.Services.AddSingleton(ruAttachments);

            List<WeaponModel> euWeapons = new WeaponModel().GetAllWeapons(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<WeaponModel> ruWeapons = new WeaponModel().GetAllWeapons(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            allEuItems.AddRange(Item.IItemToItem(euWeapons));
            allRuItems.AddRange(Item.IItemToItem(ruWeapons));
            builder.Services.AddSingleton(euWeapons);
            builder.Services.AddSingleton(ruWeapons);

            List<ArtefactModel> euArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<ArtefactModel> ruArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            allEuItems.AddRange(Item.IItemToItem(euArtefacts));
            allRuItems.AddRange(Item.IItemToItem(ruArtefacts));
            builder.Services.AddSingleton(euArtefacts);
            builder.Services.AddSingleton(ruArtefacts);

            List<ContainerModel> euContainers = new ContainerModel().GetAllContainers(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<ContainerModel> ruContainers = new ContainerModel().GetAllContainers(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            allEuItems.AddRange(Item.IItemToItem(euContainers));
            allRuItems.AddRange(Item.IItemToItem(ruContainers));
            builder.Services.AddSingleton(euContainers);
            builder.Services.AddSingleton(ruContainers);

            List<ArmorModel> euArmors = new ArmorModel().GetAllArmors(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<ArmorModel> ruArmors = new ArmorModel().GetAllArmors(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            allEuItems.AddRange(Item.IItemToItem(euArmors));
            allRuItems.AddRange(Item.IItemToItem(ruArmors));
            builder.Services.AddSingleton(euArmors);
            builder.Services.AddSingleton(ruArmors);

            //builder.Services.AddSingleton<IEnumerable<Item>>(allEuItems);
            //builder.Services.AddSingleton<IEnumerable<Item>>(allRuItems);


            //check if all classes are supported
            List<string> classes = [];
            List<string> databaseClasses = [
                "Clothing", "Combat", "Combo", "Scientist",
                "Backpacks and Containers",
                "Biochemical", "Electrophysical", "Gravitational", "Thermal",
                "Assault Rifles", "Devices", "Other Weapons", "Machine Guns", "Melee Weapons", "Pistols", "Shotguns and Rifles", "Sniper Rifles", "Submachine Guns",
                "Muzzles and Silencers", "Sights", "Hanguards and Brackets", "Magazines", "Other Attachments", "Pistol Grips",
                "Medicine",
                "Grenades",
                "Rounds",
                "Skins and Paint",
                "Barter",
                "Other"
                ];
            foreach (var item in allEuItems)
            {
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class)){
                    classes.Add(item.Class);
                    Console.WriteLine("Class: " + item.Class);
                }
            }
            foreach (var item in allRuItems)
            {
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class))
                {
                    classes.Add(item.Class);
                    Console.WriteLine("Class: " + item.Class);
                }
            }
            if (classes.Count > 0)
            {
                throw new Exception("Class is not supported");
            }


            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Guide/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Guide}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
