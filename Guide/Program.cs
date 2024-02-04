using Guide.Models;
using Microsoft.EntityFrameworkCore;
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

            List<ArtefactModel> artefacts = new ArtefactModel().GetAllArtefacts();
            builder.Services.AddSingleton<List<ArtefactModel>>(artefacts);

            List<ContainerModel> containers = new ContainerModel().GetAllContainers();
            builder.Services.AddSingleton<List<ContainerModel>>(containers);

            List<ArmorModel> armors = new ArmorModel().GetAllArmors();
            builder.Services.AddSingleton<List<ArmorModel>>(armors);

            List<IItem> allItems = new List<IItem>();
            allItems.Concat(artefacts)
                .Concat(containers)
                .Concat(armors)
                .ToList();

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
