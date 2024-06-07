using Guide.Models.DatabaseModels;
using Guide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Artefact.Controllers
{
    public class ArtefactBuilderController : Controller
    {
        private readonly ILogger<ArtefactBuilderController> _logger;
        private List<ArtefactModel> _artefacts;
        private List<ContainerModel> _containers;

        public ArtefactBuilderController(ILogger<ArtefactBuilderController> logger, List<ArtefactModel> artefacts, List<ContainerModel> containers)
        {
            _logger = logger;
            _artefacts = artefacts;
            _containers = containers;
        }

        public IActionResult Index()
        {
            var viewModel = new ArtefactBuilderViewModel(_artefacts, _containers);
            return View(viewModel);
        }
    }
}
