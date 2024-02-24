using Guide.Models;
using Guide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;

namespace Database.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly ILogger<DatabaseController> _logger;
        private List<ArtefactModel> _artefacts;
        private List<ContainerModel> _containers;
        private List<ArmorModel> _armors;
        private List<WeaponModel> _weapons;
        private List<AttachmentModel> _attachments;
        private List<BulletModel> _bullets;
        public DatabaseController(ILogger<DatabaseController> logger, List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armor, List<WeaponModel> weapons, List<AttachmentModel> attachments, List<BulletModel> bullets)
        {
            _logger = logger;
            _artefacts = artefacts;
            _containers = containers;
            _armors = armor;
            _weapons = weapons;
            _attachments = attachments;
            _bullets = bullets;
        }

        public IActionResult Index()
        {
            var viewModel = new DatabaseViewModel(_artefacts, _containers, _armors, _weapons, _attachments, _bullets);
            return View(viewModel);
        }
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
    }
}
