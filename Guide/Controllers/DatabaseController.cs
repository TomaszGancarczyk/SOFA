using Guide.Models;
using Guide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    public class DatabaseController(List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armor, List<WeaponModel> weapons, List<AttachmentModel> attachments, List<BulletModel> bullets, List<GrenadeModel> grenades, List<MedicineModel> medicines, List<OtherModel> others) : Controller
    {
        private readonly List<ArtefactModel> _artefacts = artefacts;
        private readonly List<ContainerModel> _containers = containers;
        private readonly List<ArmorModel> _armors = armor;
        private readonly List<WeaponModel> _weapons = weapons;
        private readonly List<AttachmentModel> _attachments = attachments;
        private readonly List<BulletModel> _bullets = bullets;
        private readonly List<GrenadeModel> _grenades = grenades;
        private readonly List<MedicineModel> _medicines = medicines;
        private readonly List<OtherModel> _barters = others.Where(p => p.Class == "Barter").DistinctBy(p => p.Name).ToList();
        private readonly List<OtherModel> _paints = others.Where(p => p.Class == "Skins and Paint").DistinctBy(p => p.Name).ToList();
        private readonly List<OtherModel> _others = others.Where(p => p.Class == "Other").Where(p => p.Rarity == null || p.Obtained == null || p.Description == null).DistinctBy(p => p.Name).ToList();
        public IActionResult Armor(string armorId)
        {
            var viewModel = new ArmorViewModel(armorId, _armors);
            if (viewModel.Armor.Id == armorId && viewModel.Armor.ImgSource != null) return View(viewModel);
            else return RedirectToAction("Index");
        }
        public IActionResult Artefact(string artefactId)
        {
            var viewModel = new ArtefactViewModel(artefactId, _artefacts);
            if (viewModel.Artefact != null && viewModel.Artefact.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Container(string containerId)
        {
            var viewModel = new ContainerViewModel(containerId, _containers);
            if (viewModel.Container != null && viewModel.Container.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Weapon(string weaponId)
        {
            var viewModel = new WeaponViewModel(weaponId, _weapons);
            if (viewModel.Weapon != null && viewModel.Weapon.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Attachment(string attachmentId)
        {
            var viewModel = new AttachmentViewModel(attachmentId, _attachments);
            if (viewModel.Attachment != null && viewModel.Attachment.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Bullet(string bulletId)
        {
            var viewModel = new BulletViewModel(bulletId, _bullets);
            if (viewModel.Bullet != null && viewModel.Bullet.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Grenade(string grenadeId)
        {
            var viewModel = new GrenadeViewModel(grenadeId, _grenades);
            if (viewModel.Grenade != null && viewModel.Grenade.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Medicine(string medicineId)
        {
            var viewModel = new MedicineViewModel(medicineId, _medicines);
            if (viewModel.Medicine != null && viewModel.Medicine.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Barter(string barterId)
        {
            var viewModel = new BarterViewModel(barterId, _barters);
            if (viewModel.Barter != null && viewModel.Barter.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Paint(string paintid)
        {
            var viewModel = new PaintViewModel(paintid, _paints);
            if (viewModel.Paint != null && viewModel.Paint.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Other(string otherId)
        {
            var viewModel = new OtherViewModel(otherId, _others);
            if (viewModel.Other != null && viewModel.Other.ImgSource != null) return View(viewModel);
            return RedirectToAction("Index");
        }
    }
}
