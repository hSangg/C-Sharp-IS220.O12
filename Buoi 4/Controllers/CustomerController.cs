using Lab4.data;
using Lab4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ApplicationDbContext _db;

        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public ActionResult Index(string filters)
        {
            List<Customer> customers = new List<Customer>();

            if (filters == "Highest")
            {
                Customer customerWithMaxTotalPrice = _db.customers
                    .OrderByDescending(c => c.Orders.Max(o => o.totalPrice))
                    .FirstOrDefault();

                if (customerWithMaxTotalPrice != null)
                {
                    return View("Details", customerWithMaxTotalPrice);
                }
                else
                {
                    // Xử lý trường hợp không có khách hàng
                    return View("NoData");
                }
            }
            else
            {
                customers = _db.customers.ToList();
            }

            return View("Index", customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
