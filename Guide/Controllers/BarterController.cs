using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Barter.Controllers
{
    public class BarterController : Controller
    {
        private readonly ILogger<BarterController> _logger;

        public BarterController(ILogger<BarterController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
