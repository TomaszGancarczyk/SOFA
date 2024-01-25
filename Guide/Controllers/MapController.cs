using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Map.Controllers
{
    public class MapController : Controller
    {
        private readonly ILogger<MapController> _logger;

        public MapController(ILogger<MapController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
