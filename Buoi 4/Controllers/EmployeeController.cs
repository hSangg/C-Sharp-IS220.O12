using Lab4.data;
using Lab4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        private readonly ILogger<EmployeeController> _logger;
        private readonly ApplicationDbContext _db;

        public EmployeeController(ILogger<EmployeeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public ActionResult Index(string filters)
        {
            List<Employee> employees = new List<Employee>();    

            if (filters == "0")
            {
                employees = _db.employees
                     .Where(employees => employees.Orders.Count() == 0)
                     .ToList();
            }
            else
            {
                employees = _db.employees.ToList();
            }

            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _db.employees.Add(employee);
                    _db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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
