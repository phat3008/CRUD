using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Entities;

namespace WebAppCRUD.Controllers
{
    public class KhoasController : Controller
    {
        private readonly WebCrudContext _context;

        public KhoasController(WebCrudContext context)
        {
            _context = context;
        }

        // GET: Khoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Khoas.ToListAsync());
        }

        // GET: Khoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }


        // POST: Khoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(string name)
        {
            Khoa news = new Khoa()
            {
                Name = name,

            };
            _context.Khoas.Add(news);
            _context.SaveChanges();
            return Ok(news);
        }



        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, string name)
        {
            if (id == null || string.IsNullOrEmpty(name))
            {
                return BadRequest(new { success = false, message = "Invalid data" });
            }

            // Giới hạn độ dài của name (giả sử độ dài tối đa của cột 'Name' là 50)
            int maxLength = 50;
            if (name.Length > maxLength)
            {
                name = name.Substring(0, maxLength);
            }

            var news = await _context.Khoas.FirstOrDefaultAsync(x => x.Id == id);
            if (news == null)
            {
                return BadRequest(new { success = false, message = "News item not found" });
            }

            news.Name = name;

            try
            {
                _context.Khoas.Update(news);
                await _context.SaveChangesAsync();
                return Ok(new { success = true, message = "News updated successfully" });
            }
            catch (DbUpdateException ex)
            {
                var innerExceptionMessage = ex.InnerException?.Message ?? ex.Message;
                Console.WriteLine($"Error occurred: {innerExceptionMessage}");
                return StatusCode(500, new { success = false, message = $"Internal server error. Please try again later. Details: {innerExceptionMessage}" });
            }
        }


        // POST: Khoas/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var news = _context.Khoas.FirstOrDefault(x => x.Id == id);
            _context.Khoas.Remove(news);
            _context.SaveChanges();
            return Ok();
        }
    }
}
