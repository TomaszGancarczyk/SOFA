using Barter.Controllers;
using Guide.Models.DatabaseModels;
using Guide.Models.ViewModels;
using Guide.Services;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    public class DatabaseController(ILogger<DatabaseController> logger, List<Item> allItems) : Controller
    {
        private readonly ILogger<DatabaseController> _logger;

        private readonly List<Item> _allItems = allItems;
        public IActionResult Index(string item)
        {
            Item itemModel = _allItems.FirstOrDefault(p => p.Id == item);
            if (itemModel == null)
            {
                return RedirectToAction("Error", "Database", new { message = $"Cannot find item: {item}" });
            }
            var viewModel = new ItemViewModel(itemModel);
            if (viewModel.Item.ImgSource != null) return View(viewModel);
            else
            {
                return RedirectToAction("Error", "Database", new { message = $"Image doesn't exist for Id: {viewModel.Item.Id}" });
            }
        }
        public IActionResult Error(string message)
        {
            logger.LogWarning(message);
            return View();
        }
    }
}
