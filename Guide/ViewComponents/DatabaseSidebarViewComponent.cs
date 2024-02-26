using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Guide.Models;
using Guide.Models.ViewModels;
using Database.Controllers;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Guide.ViewComponents
{
    public class DatabaseSidebar : ViewComponent
    {
        private readonly ILogger<DatabaseController> _logger;
        private readonly List<ArtefactModel> _artefacts;
        private readonly List<ContainerModel> _containers;
        private readonly List<ArmorModel> _armors;
        private readonly List<WeaponModel> _weapons;
        private readonly List<AttachmentModel> _attachments;
        private readonly List<BulletModel> _bullets;

        public DatabaseSidebar(ILogger<DatabaseController> logger, List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armor, List<WeaponModel> weapons, List<AttachmentModel> attachments, List<BulletModel> bullets)
        {
            _logger = logger;
            _artefacts = artefacts;
            _containers = containers;
            _armors = armor;
            _weapons = weapons;
            _attachments = attachments;
            _bullets = bullets;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new DatabaseViewModel(_artefacts, _containers, _armors, _weapons, _attachments, _bullets);
            return View(viewModel);
        }
    }
}
