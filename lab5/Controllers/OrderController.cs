

using CshartpLab5.data;
using CshartpLab5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;


namespace CshartpLab5.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrderController> _logger;  
        private readonly IHttpContextAccessor _contextAccessor;

        public OrderController(ApplicationDbContext context, IHttpContextAccessor contextAccessor, ILogger<OrderController> logger)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _logger = logger;
        }
        [Route("List")]
        public IActionResult Order()
        {
            var monan = _context.monan.ToList();
            return View(monan);
        }
        static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string randomString = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
        // Post: OrderController/Order/PlaceOrder
        public IActionResult PlaceOrder(List<int> Quantity, List<string> MAMA, List<String> kem, string total) 
        {
            DateTime curDate = DateTime.Now;
            string id = GenerateRandomString(9);
            var hoadon = new HOADON
            {
                MAHD = id,
                MAKH = _contextAccessor.HttpContext.Session.GetString("makh"),
                THT = total != null ? decimal.Parse(total) : 0,
                NGAYHD = curDate,
            };
            _context.hoadon.Add(hoadon);
            _context.SaveChanges();
            for (int i = 0; i < MAMA.Count(); i++)
            {
                if (Quantity[i] > 0)
                {
                    var cthd = new CTHD
                    {
                        MAHD = id,
                        MAMA = MAMA[i],
                        MAK = null,
                        SL = Quantity[i]
                    };
                    _context.CTHD.Add(cthd);
                    _context.SaveChanges();
                }
            }
            
            return View("Order", _context.monan.ToList());
        }

        // GET: OrderController/Details/5
        [Route("Order/Detail")]
        [HttpGet]
        public ActionResult Details(string id)
        {
            var hoadon = _context.hoadon.Where(hd=> hd.MAHD == id).FirstOrDefault();
            return View("Details",hoadon);
        }
        [Route("Order/Order/ListMon")]
        public ActionResult ListMon(string MAHD)
        {
            List<CTHD> list = new List<CTHD>();
            Console.WriteLine(MAHD);
            list = _context.CTHD.Where(cthd => cthd.MAHD == MAHD).ToList();
            Console.WriteLine("hhgngedgsdiopghsdihpgsdiphgsp");
            return PartialView("ListMon", list);
        }

        [Route("Order/Monan")]
        [HttpGet]
        public ActionResult getName(string MAMA)
        {
            Monan monan = new Monan();
            monan = _context.monan.Where(monan=> monan.MAMA == MAMA).FirstOrDefault();
            return Json(monan);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
