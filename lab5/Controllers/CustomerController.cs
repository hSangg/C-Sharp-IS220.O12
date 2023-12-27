using CshartpLab5.data;
using CshartpLab5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CshartpLab5.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDbContext _context;

        public CustomerController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
            _context = context;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var customers = _context.khachhang.ToList();
            ViewBag.customer = new SelectList(customers, "MAKH", "FullName");
            return View("Index",_context.hoadon.ToList());
        }

        [Route("Customer/GetDetails")]
        public IActionResult GetDetails(string selectedId)
        {
                List<HOADON> hoadons = new List<HOADON>();
                hoadons = _context.hoadon.Where(hd => hd.MAKH == selectedId).ToList();
                return PartialView("_DetailsPartial", hoadons.ToList());
        }
        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Route("Customer/Delete")]
        public ActionResult Delete(string MAHD)
        {
            Console.WriteLine(MAHD);
            var itemToDelete = _context.hoadon.Find(MAHD);
            Console.WriteLine("đã gọi");
            if (itemToDelete != null)
            {
                _context.hoadon.Remove(itemToDelete);
                _context.SaveChanges();
            }
            return Json(new { success = true });
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
