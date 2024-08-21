using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estoquei.Models;

namespace Estoquei.Controllers
{
    public class EntradaESaidaController : Controller
    {
        private readonly Contexto _context;

        public EntradaESaidaController(Contexto context)
        {
            _context = context;
        }

        // GET: EntradaESaida
        public async Task<IActionResult> Index()
        {
            var contexto = _context.EntradaESaida.Include(e => e.Produto);
            return View(await contexto.ToListAsync());
        }

        // GET: EntradaESaida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EntradaESaida == null)
            {
                return NotFound();
            }

            var entradaESaida = await _context.EntradaESaida
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaESaida == null)
            {
                return NotFound();
            }

            return View(entradaESaida);
        }

        // GET: EntradaESaida/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id");
            return View();
        }

        // POST: EntradaESaida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,QuantidadeMovimento,IdTipoMovimentacao,DataMovimentacao")] EntradaESaida entradaESaida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaESaida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", entradaESaida.ProdutoId);
            return View(entradaESaida);
        }

        // GET: EntradaESaida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EntradaESaida == null)
            {
                return NotFound();
            }

            var entradaESaida = await _context.EntradaESaida.FindAsync(id);
            if (entradaESaida == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", entradaESaida.ProdutoId);
            return View(entradaESaida);
        }

        // POST: EntradaESaida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,QuantidadeMovimento,IdTipoMovimentacao,DataMovimentacao")] EntradaESaida entradaESaida)
        {
            if (id != entradaESaida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaESaida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaESaidaExists(entradaESaida.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", entradaESaida.ProdutoId);
            return View(entradaESaida);
        }

        // GET: EntradaESaida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EntradaESaida == null)
            {
                return NotFound();
            }

            var entradaESaida = await _context.EntradaESaida
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaESaida == null)
            {
                return NotFound();
            }

            return View(entradaESaida);
        }

        // POST: EntradaESaida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EntradaESaida == null)
            {
                return Problem("Entity set 'Contexto.EntradaESaida'  is null.");
            }
            var entradaESaida = await _context.EntradaESaida.FindAsync(id);
            if (entradaESaida != null)
            {
                _context.EntradaESaida.Remove(entradaESaida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaESaidaExists(int id)
        {
          return (_context.EntradaESaida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
