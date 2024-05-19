using Guide.Models;
using Guide.Services;

namespace Guide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = factory.CreateLogger("Guide");

            logger.LogInformation("App started");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            BarterModel barters = BarterModel.GetBarter(Shared.GetEuDatabasePath());
            builder.Services.AddSingleton(barters);

            List<Item> allItems = [];

            List<OtherModel> euOthers = new OtherModel().GetAllOthers(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            //List<OtherModel> ruOthers = new OtherModel().GetAllOthers(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euOthers);
            //builder.Services.AddSingleton(ruOthers);
            foreach (var item in euOthers) allItems.Add(Shared.CreateItemFromModel(item));
            logger.LogInformation("Other model created");

            List<MedicineModel> euMedicines = new MedicineModel().GetAllMedicines(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            //List<MedicineModel> ruMedicines = new MedicineModel().GetAllMedicines(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euMedicines);
            //builder.Services.AddSingleton(ruMedicines);
            foreach (var item in euMedicines) allItems.Add(Shared.CreateItemFromModel(item));
            logger.LogInformation("Medicine model created");

            List<GrenadeModel> euGrenades = new GrenadeModel().GetAllGrenades(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            //List<GrenadeModel> ruGrenades = new GrenadeModel().GetAllGrenades(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euGrenades);
            //builder.Services.AddSingleton(ruGrenades);
            foreach (var item in euGrenades) allItems.Add(Shared.CreateItemFromModel(item));
            logger.LogInformation("Grenade model created");

            List<BulletModel> euBullets = new BulletModel().GetAllBullets(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            //List<BulletModel> ruBullets = new BulletModel().GetAllBullets(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euBullets);
            //builder.Services.AddSingleton(ruBullets);
            foreach (var item in euBullets) allItems.Add(Shared.CreateItemFromModel(item));
            logger.LogInformation("Bullet model created");

            List<AttachmentModel> euAttachments = new AttachmentModel().GetAllAttachments(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            //List<AttachmentModel> ruAttachments = new AttachmentModel().GetAllAttachments(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euAttachments);
            //builder.Services.AddSingleton(ruAttachments);
            foreach (var item in euAttachments) allItems.Add(Shared.CreateItemFromModel(item));
            logger.LogInformation("Attachment model created");

            List<WeaponModel> euWeapons = new WeaponModel().GetAllWeapons(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            //List<WeaponModel> ruWeapons = new WeaponModel().GetAllWeapons(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euWeapons);
            //builder.Services.AddSingleton(ruWeapons);
            foreach (var item in euWeapons) allItems.Add(Shared.CreateItemFromModel(item));
            logger.LogInformation("Weapon model created");

            List<ArtefactModel> euArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            //List<ArtefactModel> ruArtefacts = new ArtefactModel().GetAllArtefacts(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euArtefacts);
            //builder.Services.AddSingleton(ruArtefacts);
            foreach (var item in euArtefacts) allItems.Add(Shared.CreateItemFromModel(item));
            logger.LogInformation("Artefact model created");

            List<ContainerModel> euContainers = new ContainerModel().GetAllContainers(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            //List<ContainerModel> ruContainers = new ContainerModel().GetAllContainers(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euContainers);
            //builder.Services.AddSingleton(ruContainers);
            foreach (var item in euContainers) allItems.Add(Shared.CreateItemFromModel(item));
            logger.LogInformation("Container model created");

            List<ArmorModel> euArmors = new ArmorModel().GetAllArmors(Shared.GetEuDatabasePath()).OrderBy(p => p.Name).ToList();
            //List<ArmorModel> ruArmors = new ArmorModel().GetAllArmors(Shared.GetRuDatabasePath()).OrderBy(p => p.Name).ToList();
            builder.Services.AddSingleton(euArmors);
            //builder.Services.AddSingleton(ruArmors);
            foreach (var item in euArmors) allItems.Add(Shared.CreateItemFromModel(item));
            logger.LogInformation("Armor model created");

            builder.Services.AddSingleton(allItems);
            logger.LogInformation("All model added");

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
