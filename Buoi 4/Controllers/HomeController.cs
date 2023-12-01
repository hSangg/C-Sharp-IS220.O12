using Lab4.data;
using Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(string filters)
        {
            List<Supplier> suppliers = new List<Supplier>();

            if (filters == "top10")
            {
                suppliers = _db.suppliers
                    .Where(supplier => supplier.products.Count() >= 10)
                    .ToList();
            }
            else if (filters == "nope")
            {
                suppliers = _db.suppliers
                    .Where(supplier => supplier.products.Count() == 0)
                    .ToList();
            }
            else
            {
                // Mặc định lấy tất cả suppliers
                suppliers = _db.suppliers.ToList();
            }

            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _db.suppliers.Add(supplier);
                    _db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}