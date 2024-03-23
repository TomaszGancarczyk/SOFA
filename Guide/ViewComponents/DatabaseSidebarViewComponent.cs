using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Guide.Models;
using Guide.Models.ViewModels;
using Database.Controllers;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Guide.ViewComponents
{
    public class DatabaseSidebar(List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armor, List<WeaponModel> weapons, List<AttachmentModel> attachments, List<BulletModel> bullets, List<GrenadeModel> grenades, List<MedicineModel> medicines, List<OtherModel> others) : ViewComponent
    {
        private readonly List<ArtefactModel> _artefacts = artefacts;
        private readonly List<ContainerModel> _containers = containers;
        private readonly List<ArmorModel> _armors = armor;
        private readonly List<WeaponModel> _weapons = weapons;
        private readonly List<AttachmentModel> _attachments = attachments;
        private readonly List<BulletModel> _bullets = bullets;
        private readonly List<GrenadeModel> _grenades = grenades;
        private readonly List<MedicineModel> _medicines = medicines;
        private readonly List<OtherModel> _other = others;

        public IViewComponentResult Invoke()
        {
            var viewModel = new DatabaseViewModel(_artefacts, _containers, _armors, _weapons, _attachments, _bullets, _grenades, _medicines, _other);
            return View(viewModel);
        }
    }
}
