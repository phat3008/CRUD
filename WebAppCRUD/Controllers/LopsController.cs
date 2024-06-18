using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Entities;

namespace WebApp.Controllers
{
    public class LopsController : Controller
    {
        private readonly WebCrudContext _context;

        public LopsController(WebCrudContext context)
        {
            _context = context;
        }

        // GET: Lops
        public async Task<IActionResult> Index()
        {
            ViewData["Khoa"] = _context.Khoas.ToList();
            return View(await _context.Lops.ToListAsync());
        }

        // GET: Lops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lop = await _context.Lops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lop == null)
            {
                return NotFound();
            }

            return View(lop);
        }

        // POST: Lops/Create
        [HttpPost]
        public IActionResult Create(string name, int Khoa)
        {
            Lop news = new Lop()
            {
                Name = name,
                Khoa = Khoa,
            };
            _context.Lops.Add(news);
            _context.SaveChanges();
            return Ok(news);
        }

        // POST: Lops/Edit
        [HttpPost]
        public IActionResult Edit(int id, string name, int khoa)
        {
            var lop = _context.Lops.Find(id);
            if (lop == null)
            {
                return NotFound();
            }

            lop.Name = name;
            lop.Khoa = khoa;

            _context.SaveChanges();
            return Ok(lop);
        }


        // POST: Lops/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var lop = _context.Lops.FirstOrDefault(x => x.Id == id);
            if (lop == null)
            {
                return NotFound("Không tìm thấy lớp.");
            }

            _context.Lops.Remove(lop);
            _context.SaveChanges();
            return Ok();
        }
    }
}
