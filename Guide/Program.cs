using Guide.Models;
using Guide.Services;

namespace Guide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            List<OtherModel> euOthers = new OtherModel().GetAllOthers(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<OtherModel> ruOthers = new OtherModel().GetAllOthers(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euOthers);
            builder.Services.AddSingleton(ruOthers);

            List<MedicineModel> euMedicines = new MedicineModel().GetAllMedicines(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<MedicineModel> ruMedicines = new MedicineModel().GetAllMedicines(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euMedicines);
            builder.Services.AddSingleton(ruMedicines);

            List<GrenadeModel> euGrenades = new GrenadeModel().GetAllGrenades(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<GrenadeModel> ruGrenades = new GrenadeModel().GetAllGrenades(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euGrenades);
            builder.Services.AddSingleton(ruGrenades);

            List<BulletModel> euBullets = new BulletModel().GetAllBullets(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<BulletModel> ruBullets = new BulletModel().GetAllBullets(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euBullets);
            builder.Services.AddSingleton(ruBullets);

            List<AttachmentModel> euAttachments = new AttachmentModel().GetAllAttachments(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<AttachmentModel> ruAttachments = new AttachmentModel().GetAllAttachments(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euAttachments);
            builder.Services.AddSingleton(ruAttachments);

            List<WeaponModel> euWeapons = new WeaponModel().GetAllWeapons(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<WeaponModel> ruWeapons = new WeaponModel().GetAllWeapons(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euWeapons);
            builder.Services.AddSingleton(ruWeapons);

            List<ArtefactModel> euArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<ArtefactModel> ruArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euArtefacts);
            builder.Services.AddSingleton(ruArtefacts);

            List<ContainerModel> euContainers = new ContainerModel().GetAllContainers(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<ContainerModel> ruContainers = new ContainerModel().GetAllContainers(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euContainers);
            builder.Services.AddSingleton(ruContainers);

            List<ArmorModel> euArmors = new ArmorModel().GetAllArmors(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            List<ArmorModel> ruArmors = new ArmorModel().GetAllArmors(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euArmors);
            builder.Services.AddSingleton(ruArmors);

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
