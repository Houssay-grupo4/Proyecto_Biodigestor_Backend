using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Biodigestor.Models;

namespace Proyecto.Biodigestor.Controllers
{
    public class ProvisionesController : Controller
    {
        private readonly ProvisionesContext _context;

        public ProvisionesController(ProvisionesContext context)
        {
            _context = context;
        }

        // GET: Provisiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provisiones.ToListAsync());
        }

        // GET: Provisiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provision = await _context.Provisiones
                .FirstOrDefaultAsync(m => m.IdProvision == id);
            if (provision == null)
            {
                return NotFound();
            }

            return View(provision);
        }

        // GET: Provisiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provisiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProvision,Fecha,CantidadGas,Descripcion")] Provision provision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provision);
        }

        // GET: Provisiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provision = await _context.Provisiones.FindAsync(id);
            if (provision == null)
            {
                return NotFound();
            }
            return View(provision);
        }

        // POST: Provisiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProvision,Fecha,CantidadGas,Descripcion")] Provision provision)
        {
            if (id != provision.IdProvision)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvisionExists(provision.IdProvision))
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
            return View(provision);
        }

        // GET: Provisiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provision = await _context.Provisiones
                .FirstOrDefaultAsync(m => m.IdProvision == id);
            if (provision == null)
            {
                return NotFound();
            }

            return View(provision);
        }

        // POST: Provisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provision = await _context.Provisiones.FindAsync(id);
            if (provision != null)
            {
                _context.Provisiones.Remove(provision);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvisionExists(int id)
        {
            return _context.Provisiones.Any(e => e.IdProvision == id);
        }
    }
}
