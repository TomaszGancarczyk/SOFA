using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class MarketController : Controller
    {
        private readonly ILogger<MarketController> _logger;

        public MarketController(ILogger<MarketController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
