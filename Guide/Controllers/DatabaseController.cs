using Guide.Models;
using Guide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;

namespace Database.Controllers
{
    public class DatabaseController(ILogger<DatabaseController> logger, List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armor, List<WeaponModel> weapons, List<AttachmentModel> attachments, List<BulletModel> bullets, List<GrenadeModel> grenades, List<MedicineModel> medicines) : Controller
    {
        private readonly ILogger<DatabaseController> _logger = logger;
        private readonly List<ArtefactModel> _artefacts = artefacts;
        private readonly List<ContainerModel> _containers = containers;
        private readonly List<ArmorModel> _armors = armor;
        private readonly List<WeaponModel> _weapons = weapons;
        private readonly List<AttachmentModel> _attachments = attachments;
        private readonly List<BulletModel> _bullets = bullets;
        private readonly List<GrenadeModel> _grenades = grenades;
        private readonly List<MedicineModel> _medicines = medicines;
        public IActionResult Armor(string armorId)
        {
            var viewModel = new ArmorViewModel(armorId, _armors);
            return View(viewModel);
        }
        public IActionResult Artefact(string artefactId)
        {
            var viewModel = new ArtefactViewModel(artefactId, _artefacts);
            return View(viewModel);
        }
        public IActionResult Container(string containerId)
        {
            var viewModel = new ContainerViewModel(containerId, _containers);
            return View(viewModel);
        }
        public IActionResult Weapon(string weaponId)
        {
            var viewModel = new WeaponViewModel(weaponId, _weapons);
            return View(viewModel);
        }
        public IActionResult Attachment(string attachmentId)
        {
            var viewModel = new AttachmentViewModel(attachmentId, _attachments);
            return View(viewModel);
        }
        public IActionResult Bullet(string bulletId)
        {
            var viewModel = new BulletViewModel(bulletId, _bullets);
            return View(viewModel);
        }
        public IActionResult Grenade(string grenadeId)
        {
            var viewModel = new GrenadeViewModel(grenadeId, _grenades);
            return View(viewModel);
        }
        public IActionResult Medicine(string medicineId)
        {
            var viewModel = new MedicineViewModel(medicineId, _medicines);
            return View(viewModel);
        }
    }
}
