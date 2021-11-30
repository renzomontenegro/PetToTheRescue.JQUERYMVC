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
    public class MascotasPerdidasController : Controller
    {
        private readonly PetsToTheRescueContext _context;

        public MascotasPerdidasController(PetsToTheRescueContext context)
        {
            _context = context;
        }

        // GET: MascotasPerdidas
        public async Task<IActionResult> Index()
        {
            var petsToTheRescueContext = _context.MascotasPerdidas.Include(m => m.Administrador).Include(m => m.Cliente);
            return View(await petsToTheRescueContext.ToListAsync());
        }

        // GET: MascotasPerdidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotasPerdidas = await _context.MascotasPerdidas
                .Include(m => m.Administrador)
                .Include(m => m.Cliente)
                .FirstOrDefaultAsync(m => m.IdMasPerdida == id);
            if (mascotasPerdidas == null)
            {
                return NotFound();
            }

            return View(mascotasPerdidas);
        }

        // GET: MascotasPerdidas/Create
        public IActionResult Create()
        {
            ViewData["AdministradorId"] = new SelectList(_context.Administrador, "IdAdministrador", "Apellidos");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Apellidos");
            return View();
        }

        // POST: MascotasPerdidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMasPerdida,NombreAnimal,Raza,Color,Edad,Sexo,Comentario,NumContacto,Foto,ClienteId,AdministradorId")] MascotasPerdidas mascotasPerdidas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascotasPerdidas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administrador, "IdAdministrador", "Apellidos", mascotasPerdidas.AdministradorId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Apellidos", mascotasPerdidas.ClienteId);
            return View(mascotasPerdidas);
        }

        // GET: MascotasPerdidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotasPerdidas = await _context.MascotasPerdidas.FindAsync(id);
            if (mascotasPerdidas == null)
            {
                return NotFound();
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administrador, "IdAdministrador", "Apellidos", mascotasPerdidas.AdministradorId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Apellidos", mascotasPerdidas.ClienteId);
            return View(mascotasPerdidas);
        }

        // POST: MascotasPerdidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMasPerdida,NombreAnimal,Raza,Color,Edad,Sexo,Comentario,NumContacto,Foto,ClienteId,AdministradorId")] MascotasPerdidas mascotasPerdidas)
        {
            if (id != mascotasPerdidas.IdMasPerdida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascotasPerdidas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotasPerdidasExists(mascotasPerdidas.IdMasPerdida))
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
            ViewData["AdministradorId"] = new SelectList(_context.Administrador, "IdAdministrador", "Apellidos", mascotasPerdidas.AdministradorId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Apellidos", mascotasPerdidas.ClienteId);
            return View(mascotasPerdidas);
        }

        // GET: MascotasPerdidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotasPerdidas = await _context.MascotasPerdidas
                .Include(m => m.Administrador)
                .Include(m => m.Cliente)
                .FirstOrDefaultAsync(m => m.IdMasPerdida == id);
            if (mascotasPerdidas == null)
            {
                return NotFound();
            }

            return View(mascotasPerdidas);
        }

        // POST: MascotasPerdidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascotasPerdidas = await _context.MascotasPerdidas.FindAsync(id);
            _context.MascotasPerdidas.Remove(mascotasPerdidas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotasPerdidasExists(int id)
        {
            return _context.MascotasPerdidas.Any(e => e.IdMasPerdida == id);
        }
    }
}
