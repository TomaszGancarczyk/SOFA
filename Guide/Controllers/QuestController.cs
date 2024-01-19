using Error.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Quest.Controllers
{
    public class QuestController : Controller
    {
        private readonly ILogger<QuestController> _logger;

        public QuestController(ILogger<QuestController> logger)
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
