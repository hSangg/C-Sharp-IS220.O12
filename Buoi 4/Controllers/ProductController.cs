using Lab4.data;
using Lab4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Lab4.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext _db;
        public ProductController(ILogger<ProductController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger; 
        }
        public ActionResult Index(string filters)
        {
            List<Product> products = new List<Product>();
            if (filters == "G")
            {
                products = _db.products
                            .Where(product => product.ProductName.StartsWith("G"))
                            .ToList();
            }
            else if (filters == "Traders")
            {
                products = _db.products
                            .Where(products => products.Supplier.SupplierName.Equals("Tokyo Traders"))
                            .ToList();
            }
            else
            {
                products = _db.products.ToList();
            }
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
