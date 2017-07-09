using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba38.Models;

namespace prueba38.Controllers
{
    public class FamiliaController : Controller
    {
        private readonly DbProducto _context;

        public FamiliaController(DbProducto context)
        {
            _context = context;        
        }

        // GET: Familia
        public async Task<IActionResult> Index()
        {
            return View(await _context.familia.Include(g => g.grupo).ToListAsync());
        }
        
        // GET: Familia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.familia
                .SingleOrDefaultAsync(m => m.ID == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        // GET: Familia/Create
        public IActionResult Create()
        {
            var grupos = new SelectList(_context.grupo,"Id","Descripcion");
            
            ViewBag.grupos = grupos;
            return View();
        }

        // POST: Familia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,IDGrupo,grupoId")] Familia familia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familia);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(familia);
        }

        // GET: Familia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var familia = await _context.familia.Include(g=>g.grupo).SingleOrDefaultAsync(m => m.ID == id);
            
            if (familia == null)
            {
                return NotFound();
            }else{
                Console.WriteLine(familia);
                var grupos = new SelectList(_context.grupo,"Id","Descripcion",familia.grupoId);
                ViewBag.grupos = grupos; 
            }
            return View(familia);
        }

        // POST: Familia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,IDGrupo,grupoId")] Familia familia)
        {
            if (id != familia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaExists(familia.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(familia);
        }

        // GET: Familia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.familia
                .SingleOrDefaultAsync(m => m.ID == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        // POST: Familia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familia = await _context.familia.SingleOrDefaultAsync(m => m.ID == id);
            _context.familia.Remove(familia);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FamiliaExists(int id)
        {
            return _context.familia.Any(e => e.ID == id);
        }
    }
}
