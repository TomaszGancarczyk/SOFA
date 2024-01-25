using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Artifact.Controllers
{
    public class ArtifactController : Controller
    {
        private readonly ILogger<ArtifactController> _logger;

        public ArtifactController(ILogger<ArtifactController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
