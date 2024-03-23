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

            List<Item> allItems = new List<Item>();

            List<OtherModel> others = new OtherModel().GetAllOthers().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(others));
            builder.Services.AddSingleton(others);

            List<MedicineModel> medicines = new MedicineModel().GetAllMedicines().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(medicines));
            builder.Services.AddSingleton(medicines);

            List<GrenadeModel> grenades = new GrenadeModel().GetAllGrenades().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(grenades));
            builder.Services.AddSingleton(grenades);

            List<BulletModel> bullets = new BulletModel().GetAllBullets().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(bullets));
            builder.Services.AddSingleton(bullets);

            List<AttachmentModel> attachments = new AttachmentModel().GetAllAttachments().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(attachments));
            builder.Services.AddSingleton(attachments);

            List<WeaponModel> weapons = new WeaponModel().GetAllWeapons().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(weapons));
            builder.Services.AddSingleton(weapons);

            List<ArtefactModel> artefacts = new ArtefactModel().GetAllArtefacts().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(artefacts));
            builder.Services.AddSingleton(artefacts);

            List<ContainerModel> containers = new ContainerModel().GetAllContainers().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(containers));
            builder.Services.AddSingleton(containers);

            List<ArmorModel> armors = new ArmorModel().GetAllArmors().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(armors));
            builder.Services.AddSingleton(armors);

            builder.Services.AddSingleton<IEnumerable<Item>>(allItems);


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
            foreach (var item in allItems)
            {
                if (!classes.Contains(item.Class) && !databaseClasses.Contains(item.Class)){
                    classes.Add(item.Class);
                    Console.WriteLine("Class: "+item.Class);
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
