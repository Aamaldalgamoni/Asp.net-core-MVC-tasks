using Microsoft.AspNetCore.Mvc;

namespace task2.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
