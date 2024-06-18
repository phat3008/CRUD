using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Entities;

namespace WebApp.Controllers
{
    public class SinhviensController : Controller
    {
        private readonly WebCrudContext _context;

        public SinhviensController(WebCrudContext context)
        {
            _context = context;
        }

        // GET: Sinhviens
        public async Task<IActionResult> Index()
        {
            var data = _context.Sinhviens.Include(i => i.LopNavigation).ToList();
            ViewData["Khoa"] = _context.Khoas.ToList();
            ViewData["Lop"] = _context.Lops.ToList();
            return View(await _context.Sinhviens.ToListAsync());
        }

        // GET: Sinhvien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Sinhvien = await _context.Sinhviens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Sinhvien == null)
            {
                return NotFound();
            }

            return View(Sinhvien);
        }


        // POST: SinhviensCreate
        [HttpPost]
        public IActionResult Create(string name, int khoa, int lop)
        {
            var sinhvien = new Sinhvien()
            {
                Name = name,
                Khoa = khoa,
                Lop = lop
            };
            _context.Sinhviens.Add(sinhvien);
            _context.SaveChanges();
            return Ok(sinhvien);
        }



        // POST : Sinhviens/Edit
        [HttpPost]
        public IActionResult Edit(int id, string name, int? Khoa, int? Lop)
        {
            var sinhvien = _context.Sinhviens.FirstOrDefault(x => x.Id == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            sinhvien.Name = name;
            if (Khoa.HasValue)
            {
                sinhvien.Khoa = Khoa.Value;
            }
            if (Lop.HasValue)
            {
                sinhvien.Lop = Lop.Value;
            }

            _context.Sinhviens.Update   (sinhvien);
            _context.SaveChanges();
            return Ok(sinhvien);
        }



        // POST: Sinhviens/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var news = _context.Sinhviens.FirstOrDefault(x => x.Id == id);
            _context.Sinhviens.Remove(news);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetLopsByKhoa(int khoaId)
        {
            var lops = _context.Lops.Where(l => l.Khoa == khoaId).ToList();
            return Ok(lops);
        }

    }
}

