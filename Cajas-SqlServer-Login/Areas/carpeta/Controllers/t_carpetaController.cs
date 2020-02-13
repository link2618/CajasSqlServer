using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cajas_SqlServer_Login.Areas.carpeta.Models;
using Cajas_SqlServer_Login.Data;
using Microsoft.AspNetCore.Authorization;

namespace Cajas_SqlServer_Login.Areas.carpeta.Controllers
{
    [Area("carpeta")]
    public class t_carpetaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public t_carpetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: carpeta/t_carpeta
        [Authorize]
        public async Task<IActionResult> Carpeta()
        {
            var applicationDbContext = _context.tcarpeta.Include(t => t.rcaja);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: carpeta/t_carpeta/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_carpeta = await _context.tcarpeta
                .Include(t => t.rcaja)
                .FirstOrDefaultAsync(m => m.idcarpeta == id);
            if (t_carpeta == null)
            {
                return NotFound();
            }

            return View(t_carpeta);
        }

        // GET: carpeta/t_carpeta/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["caja"] = new SelectList(_context.tcaja, "idtcaja", "idtcaja");
            return View();
        }

        // POST: carpeta/t_carpeta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("idcarpeta,nit,fecha_registro,fecha_cierre,caja")] t_carpeta t_carpeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t_carpeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Carpeta));
            }
            ViewData["caja"] = new SelectList(_context.tcaja, "idtcaja", "idtcaja", t_carpeta.caja);
            return View(t_carpeta);
        }

        // GET: carpeta/t_carpeta/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_carpeta = await _context.tcarpeta.FindAsync(id);
            if (t_carpeta == null)
            {
                return NotFound();
            }
            ViewData["caja"] = new SelectList(_context.tcaja, "idtcaja", "idtcaja", t_carpeta.caja);
            return View(t_carpeta);
        }

        // POST: carpeta/t_carpeta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("idcarpeta,nit,fecha_registro,fecha_cierre,caja")] t_carpeta t_carpeta)
        {
            if (id != t_carpeta.idcarpeta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t_carpeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!t_carpetaExists(t_carpeta.idcarpeta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Carpeta));
            }
            ViewData["caja"] = new SelectList(_context.tcaja, "idtcaja", "idtcaja", t_carpeta.caja);
            return View(t_carpeta);
        }

        // GET: carpeta/t_carpeta/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_carpeta = await _context.tcarpeta
                .Include(t => t.rcaja)
                .FirstOrDefaultAsync(m => m.idcarpeta == id);
            if (t_carpeta == null)
            {
                return NotFound();
            }

            return View(t_carpeta);
        }

        // POST: carpeta/t_carpeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t_carpeta = await _context.tcarpeta.FindAsync(id);
            _context.tcarpeta.Remove(t_carpeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Carpeta));
        }

        private bool t_carpetaExists(int id)
        {
            return _context.tcarpeta.Any(e => e.idcarpeta == id);
        }
    }
}
