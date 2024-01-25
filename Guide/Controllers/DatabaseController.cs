using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Database.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly ILogger<DatabaseController> _logger;

        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
