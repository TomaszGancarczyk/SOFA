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

            List<MedicineModel> medicines = new MedicineModel().GetAllMedicines().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(medicines));
            builder.Services.AddSingleton<List<MedicineModel>>(medicines);

            List<GrenadeModel> grenades = new GrenadeModel().GetAllGrenades().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(grenades));
            builder.Services.AddSingleton<List<GrenadeModel>>(grenades);

            List<BulletModel> bullets = new BulletModel().GetAllBullets().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(bullets));
            builder.Services.AddSingleton<List<BulletModel>>(bullets);

            List<AttachmentModel> attachments = new AttachmentModel().GetAllAttachments().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(attachments));
            builder.Services.AddSingleton<List<AttachmentModel>>(attachments);

            List<WeaponModel> weapons = new WeaponModel().GetAllWeapons().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(weapons));
            builder.Services.AddSingleton<List<WeaponModel>>(weapons);

            List<ArtefactModel> artefacts = new ArtefactModel().GetAllArtefacts().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(artefacts));
            builder.Services.AddSingleton<List<ArtefactModel>>(artefacts);

            List<ContainerModel> containers = new ContainerModel().GetAllContainers().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(containers));
            builder.Services.AddSingleton<List<ContainerModel>>(containers);

            List<ArmorModel> armors = new ArmorModel().GetAllArmors().OrderBy(p => p.Name).ToList();
            allItems.AddRange(Item.IItemToItem(armors));
            builder.Services.AddSingleton<List<ArmorModel>>(armors);

            builder.Services.AddSingleton<IEnumerable<Item>>(allItems);

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
