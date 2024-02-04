using Guide.Models;
using Guide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Artefact.Controllers
{
    public class ArtefactController : Controller
    {
        private readonly ILogger<ArtefactController> _logger;
        private List<ArtefactModel> _artefacts;
        private List<ContainerModel> _containers;

        public ArtefactController(ILogger<ArtefactController> logger, List<ArtefactModel> artefacts, List<ContainerModel> containers)
        {
            _logger = logger;
            _artefacts = artefacts;
            _containers = containers;
        }

        public IActionResult Index()
        {
            var viewModel = new ArtefactViewModel(_artefacts, _containers);
            return View(viewModel);
        }
    }
}
