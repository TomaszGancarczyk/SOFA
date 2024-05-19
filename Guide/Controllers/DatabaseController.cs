using Guide.Models;
using Guide.Models.ViewModels;
using Guide.Services;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    public class DatabaseController(List<Item> allItems) : Controller
    {
        private readonly List<Item> _allItems = allItems;
        public IActionResult Index(string item)
        {
            Item itemModel = _allItems.FirstOrDefault(p => p.Id == item);
            if (itemModel == null)
            {
                Console.WriteLine($"Cannot find item: {item}");
                return RedirectToAction("Error");
            }
            var viewModel = new ItemViewModel(itemModel);
            if (viewModel.Item.ImgSource != null) return View(viewModel);
            else
            {
                Console.WriteLine($"Image doesn't exist for Id: {viewModel.Item.Id}");
                return RedirectToAction("Error");
            }
        }
        public IActionResult Error() 
        { 
            return View();
        }
    }
}
