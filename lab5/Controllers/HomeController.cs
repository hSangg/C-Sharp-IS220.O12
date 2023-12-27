using CshartpLab5.Models;
using CshartpLab5.data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CshartpLab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public IActionResult Index()
        {
            //_contextAccessor.HttpContext.Session.SetString("userId","KH01");
            //_contextAccessor.HttpContext.Session.SetString("user","John");

            return View();
        }
        public IActionResult DangNhap(Account account)
        {
            string username = account.USERNAME;
            string password = account.PASSWORD;
            var check = _context.Account.SingleOrDefault(acc=>acc.USERNAME == username && acc.PASSWORD == password);
            if (check != null)
            {
                var name = _context.khachhang
                            .Where(kh => kh.MAKH == check.MAKH)
                            .Select(kh => kh.TEN);
                if (name != null)
                {
                    _contextAccessor.HttpContext.Session.SetString("name", name.First());
                }
                _contextAccessor.HttpContext.Session.SetString("username", username);
                _contextAccessor.HttpContext.Session.SetString("makh", check.MAKH);
                return View("Index");
            }
            else
            {
                if (username != null)
                {
                    ViewBag.LoginFail = "Đăng nhập thất bại";
                    return View("DangNhap");
                }
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