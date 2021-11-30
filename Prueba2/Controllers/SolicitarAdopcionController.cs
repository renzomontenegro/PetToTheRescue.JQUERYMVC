using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba2.Models;

namespace Prueba2.Controllers
{
    public class SolicitarAdopcionController : Controller
    {
        private readonly PetsToTheRescueContext _context;

        public SolicitarAdopcionController(PetsToTheRescueContext context)
        {
            _context = context;
        }

        // GET: SolicitarAdopcion
        public async Task<IActionResult> Index()
        {
            var petsToTheRescueContext = _context.SolicitarAdopcion.Include(s => s.MainMascota);
            return View(await petsToTheRescueContext.ToListAsync());
        }

        // GET: SolicitarAdopcion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitarAdopcion = await _context.SolicitarAdopcion
                .Include(s => s.MainMascota)
                .FirstOrDefaultAsync(m => m.IdMascotas == id);
            if (solicitarAdopcion == null)
            {
                return NotFound();
            }

            return View(solicitarAdopcion);
        }

        // GET: SolicitarAdopcion/Create
        public IActionResult Create()
        {
            ViewData["MainMascotaId"] = new SelectList(_context.Mascotas, "IdMascota", "Color");
            return View();
        }

        // POST: SolicitarAdopcion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMascotas,Experiencia,RazAdopcion,Actividades,TiempoFuera,Viaje,MasCasa,Veterinaria,EstEconomica,Vivienda,MainMascotaId")] SolicitarAdopcion solicitarAdopcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitarAdopcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MainMascotaId"] = new SelectList(_context.Mascotas, "IdMascota", "Color", solicitarAdopcion.MainMascotaId);
            return View(solicitarAdopcion);
        }

        // GET: SolicitarAdopcion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitarAdopcion = await _context.SolicitarAdopcion.FindAsync(id);
            if (solicitarAdopcion == null)
            {
                return NotFound();
            }
            ViewData["MainMascotaId"] = new SelectList(_context.Mascotas, "IdMascota", "Color", solicitarAdopcion.MainMascotaId);
            return View(solicitarAdopcion);
        }

        // POST: SolicitarAdopcion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMascotas,Experiencia,RazAdopcion,Actividades,TiempoFuera,Viaje,MasCasa,Veterinaria,EstEconomica,Vivienda,MainMascotaId")] SolicitarAdopcion solicitarAdopcion)
        {
            if (id != solicitarAdopcion.IdMascotas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitarAdopcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitarAdopcionExists(solicitarAdopcion.IdMascotas))
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
            ViewData["MainMascotaId"] = new SelectList(_context.Mascotas, "IdMascota", "Color", solicitarAdopcion.MainMascotaId);
            return View(solicitarAdopcion);
        }

        // GET: SolicitarAdopcion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitarAdopcion = await _context.SolicitarAdopcion
                .Include(s => s.MainMascota)
                .FirstOrDefaultAsync(m => m.IdMascotas == id);
            if (solicitarAdopcion == null)
            {
                return NotFound();
            }

            return View(solicitarAdopcion);
        }

        // POST: SolicitarAdopcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitarAdopcion = await _context.SolicitarAdopcion.FindAsync(id);
            _context.SolicitarAdopcion.Remove(solicitarAdopcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitarAdopcionExists(int id)
        {
            return _context.SolicitarAdopcion.Any(e => e.IdMascotas == id);
        }
    }
}
