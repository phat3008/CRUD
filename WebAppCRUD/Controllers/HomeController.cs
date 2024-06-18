using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAppCRUD.Entities;
using WebAppCRUD.Models;

namespace WebAppCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebCrudContext _context;

        public HomeController(ILogger<HomeController> logger, WebCrudContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Alls()
        {
        
            ViewData["Khoa"] = _context.Khoas.ToList();
            ViewData["Lop"] = _context.Lops.ToList();
            ViewData["Sinhvien"] = _context.Sinhviens.ToList();
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
