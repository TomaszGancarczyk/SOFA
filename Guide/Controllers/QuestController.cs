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
    }
}
