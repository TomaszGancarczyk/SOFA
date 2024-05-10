using Microsoft.AspNetCore.Mvc;

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
