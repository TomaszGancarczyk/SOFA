using Guide.Models.DatabaseModels;
using Guide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Barter.Controllers
{
    public class CompareController : Controller
    {
        private readonly ILogger<CompareController> _logger;

        public CompareController(ILogger<CompareController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(List<Item> items)
        {
            var viewModel = new CompareViewModel(items);
            return View(viewModel);
        }
    }
}
