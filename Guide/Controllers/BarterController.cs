using Error.Models;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
