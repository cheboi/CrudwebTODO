using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudwebTODO.Data;
using CrudwebTODO.Models;

namespace CrudwebTODO.Controllers
{
    public class TODOlistsController : Controller
    {
        private readonly ToDoContext _context;

        public TODOlistsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: TODOlists
        public async Task<IActionResult> Index()
        {
            return View(await _context.TODOlists.ToListAsync());
        }

        // GET: TODOlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tODOlist = await _context.TODOlists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tODOlist == null)
            {
                return NotFound();
            }

            return View(tODOlist);
        }

        // GET: TODOlists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TODOlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,start_Time,End_Time")] TODOlist tODOlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tODOlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tODOlist);
        }

        // GET: TODOlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tODOlist = await _context.TODOlists.FindAsync(id);
            if (tODOlist == null)
            {
                return NotFound();
            }
            return View(tODOlist);
        }

        // POST: TODOlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,start_Time,End_Time")] TODOlist tODOlist)
        {
            if (id != tODOlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tODOlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TODOlistExists(tODOlist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tODOlist);
        }

        // GET: TODOlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tODOlist = await _context.TODOlists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tODOlist == null)
            {
                return NotFound();
            }

            return View(tODOlist);
        }

        // POST: TODOlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tODOlist = await _context.TODOlists.FindAsync(id);
            _context.TODOlists.Remove(tODOlist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TODOlistExists(int id)
        {
            return _context.TODOlists.Any(e => e.Id == id);
        }
    }
}
