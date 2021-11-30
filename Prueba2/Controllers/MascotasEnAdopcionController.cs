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
    public class MascotasEnAdopcionController : Controller
    {
        private readonly PetsToTheRescueContext _context;

        public MascotasEnAdopcionController(PetsToTheRescueContext context)
        {
            _context = context;
        }

        // GET: MascotasEnAdopcion
        public async Task<IActionResult> Index()
        {
            var petsToTheRescueContext = _context.MascotasEnAdopcion.Include(m => m.Administrador).Include(m => m.Cliente);
            return View(await petsToTheRescueContext.ToListAsync());
        }

        // GET: MascotasEnAdopcion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotasEnAdopcion = await _context.MascotasEnAdopcion
                .Include(m => m.Administrador)
                .Include(m => m.Cliente)
                .FirstOrDefaultAsync(m => m.IdMasAdopcion == id);
            if (mascotasEnAdopcion == null)
            {
                return NotFound();
            }

            return View(mascotasEnAdopcion);
        }

        // GET: MascotasEnAdopcion/Create
        public IActionResult Create()
        {
            ViewData["AdministradorId"] = new SelectList(_context.Administrador, "IdAdministrador", "Apellidos");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Apellidos");
            return View();
        }

        // POST: MascotasEnAdopcion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMasAdopcion,NombreAnimal,Raza,Tipo,ColorOjos,ColorPelaje,Edad,Sexo,CondMedica,DescAnimal,RazDecision,Email,Telefono,EmaRespaldo,TelRespaldo,Foto,AdministradorId,ClienteId")] MascotasEnAdopcion mascotasEnAdopcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascotasEnAdopcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administrador, "IdAdministrador", "Apellidos", mascotasEnAdopcion.AdministradorId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Apellidos", mascotasEnAdopcion.ClienteId);
            return View(mascotasEnAdopcion);
        }

        // GET: MascotasEnAdopcion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotasEnAdopcion = await _context.MascotasEnAdopcion.FindAsync(id);
            if (mascotasEnAdopcion == null)
            {
                return NotFound();
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administrador, "IdAdministrador", "Apellidos", mascotasEnAdopcion.AdministradorId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Apellidos", mascotasEnAdopcion.ClienteId);
            return View(mascotasEnAdopcion);
        }

        // POST: MascotasEnAdopcion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMasAdopcion,NombreAnimal,Raza,Tipo,ColorOjos,ColorPelaje,Edad,Sexo,CondMedica,DescAnimal,RazDecision,Email,Telefono,EmaRespaldo,TelRespaldo,Foto,AdministradorId,ClienteId")] MascotasEnAdopcion mascotasEnAdopcion)
        {
            if (id != mascotasEnAdopcion.IdMasAdopcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascotasEnAdopcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotasEnAdopcionExists(mascotasEnAdopcion.IdMasAdopcion))
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
            ViewData["AdministradorId"] = new SelectList(_context.Administrador, "IdAdministrador", "Apellidos", mascotasEnAdopcion.AdministradorId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Apellidos", mascotasEnAdopcion.ClienteId);
            return View(mascotasEnAdopcion);
        }

        // GET: MascotasEnAdopcion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotasEnAdopcion = await _context.MascotasEnAdopcion
                .Include(m => m.Administrador)
                .Include(m => m.Cliente)
                .FirstOrDefaultAsync(m => m.IdMasAdopcion == id);
            if (mascotasEnAdopcion == null)
            {
                return NotFound();
            }

            return View(mascotasEnAdopcion);
        }

        // POST: MascotasEnAdopcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascotasEnAdopcion = await _context.MascotasEnAdopcion.FindAsync(id);
            _context.MascotasEnAdopcion.Remove(mascotasEnAdopcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotasEnAdopcionExists(int id)
        {
            return _context.MascotasEnAdopcion.Any(e => e.IdMasAdopcion == id);
        }
    }
}
