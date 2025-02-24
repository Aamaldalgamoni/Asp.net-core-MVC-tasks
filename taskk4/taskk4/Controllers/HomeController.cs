using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using taskk4.Models;

namespace taskk4.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _logger;

        public HomeController(MyDbContext logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var store = _logger.Stores.ToList();
            return View(store);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                _logger.Stores.Add(store);
                _logger.SaveChanges();
                return RedirectToAction("Index");

            }
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
