using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cajas_SqlServer_Login.Areas.tipo_caja.Models;
using Cajas_SqlServer_Login.Data;
using Microsoft.AspNetCore.Authorization;

namespace Cajas_SqlServer_Login.Areas.tipo_caja.Controllers
{
    [Area("tipo_caja")]
    public class t_tipo_cajaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public t_tipo_cajaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tipo_caja/t_tipo_caja
        [Authorize]
        public async Task<IActionResult> Tipo_Caja()
        {
            return View(await _context.ttipocaja.ToListAsync());
            //return View();
        }

        // GET: tipo_caja/t_tipo_caja/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_tipo_caja = await _context.ttipocaja
                .FirstOrDefaultAsync(m => m.idtipocaja == id);
            if (t_tipo_caja == null)
            {
                return NotFound();
            }

            return View(t_tipo_caja);
        }

        // GET: tipo_caja/t_tipo_caja/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: tipo_caja/t_tipo_caja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("idtipocaja,nombre")] t_tipo_caja t_tipo_caja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t_tipo_caja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Tipo_Caja));
            }
            return View(t_tipo_caja);
        }

        // GET: tipo_caja/t_tipo_caja/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_tipo_caja = await _context.ttipocaja.FindAsync(id);
            if (t_tipo_caja == null)
            {
                return NotFound();
            }
            return View(t_tipo_caja);
        }

        // POST: tipo_caja/t_tipo_caja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("idtipocaja,nombre")] t_tipo_caja t_tipo_caja)
        {
            if (id != t_tipo_caja.idtipocaja)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t_tipo_caja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!t_tipo_cajaExists(t_tipo_caja.idtipocaja))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Tipo_Caja));
            }
            return View(t_tipo_caja);
        }

        // GET: tipo_caja/t_tipo_caja/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t_tipo_caja = await _context.ttipocaja
                .FirstOrDefaultAsync(m => m.idtipocaja == id);
            if (t_tipo_caja == null)
            {
                return NotFound();
            }

            return View(t_tipo_caja);
        }

        // POST: tipo_caja/t_tipo_caja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t_tipo_caja = await _context.ttipocaja.FindAsync(id);
            _context.ttipocaja.Remove(t_tipo_caja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Tipo_Caja));
        }

        private bool t_tipo_cajaExists(int id)
        {
            return _context.ttipocaja.Any(e => e.idtipocaja == id);
        }
    }
}
