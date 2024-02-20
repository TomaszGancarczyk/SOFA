using Guide.Models;
using Guide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Database.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly ILogger<DatabaseController> _logger;
        private List<ArtefactModel> _artefacts;
        private List<ContainerModel> _containers;
        private List<ArmorModel> _armors;
        public DatabaseController(ILogger<DatabaseController> logger, List<ArtefactModel> artefacts, List<ContainerModel> containers, List<ArmorModel> armor)
        {
            _logger = logger;
            _artefacts = artefacts;
            _containers = containers;
            _armors = armor;
        }

        public IActionResult Index()
        {
            var viewModel = new DatabaseViewModel(_artefacts, _containers, _armors);
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
    }
}
