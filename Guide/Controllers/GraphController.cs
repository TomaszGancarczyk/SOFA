using Guide.Models;
using Guide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;

namespace Graph.Controllers
{
    public class GraphController(List<ArmorModel> armor, List<WeaponModel> weapons, List<BulletModel> bullets) : Controller
    {
        private readonly List<ArmorModel> _armors = armor;
        private readonly List<WeaponModel> _weapons = weapons;
        private readonly List<BulletModel> _bullets = bullets;

        public IActionResult Index()
        {
            var viewModel = new GraphViewModel(_armors, _weapons, _bullets);
            return View(viewModel);
        }
    }
}
