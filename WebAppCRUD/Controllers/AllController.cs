using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAppCRUD.Entities;

namespace WebAppCRUD.Controllers
{
    public class AllController : Controller
    {
        private readonly WebCrudContext _context;

        public AllController(WebCrudContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Khoas"] = _context.Khoas.ToList();
            ViewData["Lops"] = _context.Lops.ToList();
            ViewData["Sinhviens"] = _context.Sinhviens.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateKhoa(Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                _context.Khoas.Add(khoa);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpPost]
        public IActionResult CreateLop(Lop lop)
        {
            if (ModelState.IsValid)
            {
                _context.Lops.Add(lop);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpPost]
        public IActionResult CreateSinhvien(Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Sinhviens.Add(sinhvien);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpPost]
        public IActionResult DeleteKhoa(int id)
        {
            var khoa = _context.Khoas.Find(id);
            if (khoa == null)
            {
                return Json(new { success = false, errors = "Khoa not found" });
            }

            _context.Khoas.Remove(khoa);
            _context.SaveChanges();
            return Json(new { success = true });
        }


        [HttpPost]
        public IActionResult DeleteLop(int id)
        {
            var lop = _context.Lops.Find(id);
            if (lop == null)
            {
                return Json(new { success = false, errors = "Lop not found" });
            }

            _context.Lops.Remove(lop);
            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult DeleteSinhvien(int id)
        {
            var sinhvien = _context.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return Json(new { success = false, errors = "Sinhvien not found" });
            }

            _context.Sinhviens.Remove(sinhvien);
            _context.SaveChanges();
            return Json(new { success = true });
        }

    }
}
