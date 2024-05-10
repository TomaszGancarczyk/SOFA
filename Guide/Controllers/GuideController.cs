using Microsoft.AspNetCore.Mvc;

namespace Guide.Controllers
{
    public class GuideController : Controller
    {
        private readonly ILogger<GuideController> _logger;

        public GuideController(ILogger<GuideController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
