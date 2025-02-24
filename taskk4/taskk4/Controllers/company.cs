using Microsoft.AspNetCore.Mvc;
using taskk4.Models;

namespace taskk4.Controllers
{
    public class company : Controller
    {
        private readonly MyDbContext _context;

        public company(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var department = _context.Departments.ToList();
            return View(department);
        }
        public IActionResult ccreate()
        {
           
            return View();

        }
        [HttpPost]
        public IActionResult ccreate(Department department)
        {
            if (ModelState.IsValid)
            {
          
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();


        }
    }
}
