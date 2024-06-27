using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CtrlOrdem.Data;
using CtrlOrdem.Models;

namespace CtrlOrdem.Controllers
{
    public class OrdemsController : Controller
    {
        private readonly CtrlOrdemContext _context;

        public OrdemsController(CtrlOrdemContext context)
        {
            _context = context;
        }

        // GET: Ordems
        public async Task<IActionResult> Index()
        {
            var CtrlOrdemContext = 
                _context.Ordem
                    .Include(c => c.Cliente)
                    .Include(c => c.Tecnico)
                    .Include(c => c.Servico)
                    .Where(c => c.Status == "Aberto");

            return View(await CtrlOrdemContext.ToListAsync());
        }

        // GET: Ordems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordem = await _context.Ordem
                .Include(c => c.Cliente).Include(c => c.Tecnico).Include(c => c.Servico)
                .FirstOrDefaultAsync(m => m.OrdemId == id);
            if (ordem == null)
            {
                return NotFound();
            }

            return View(ordem);
        }

        // GET: Ordems/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteID", "NomeCompleto");
            ViewData["TecnicoId"] = new SelectList(_context.Tecnico, "TecnicoId", "Nome");
            ViewData["ServicoId"] = new SelectList(_context.Servico, "ServicoId", "Descricao");
            ViewData["Valor"] = new SelectList(_context.Servico, "ServicoId", "Valor");
            return View();
        }

        // POST: Ordems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdemId,ClienteId,TecnicoId,Abertura,ServicoId,Procedimento,Tempo,Taxas,Desconto,Observacao,Status")] Ordem ordem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordem);
        }

        // GET: Ordems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordem = await _context.Ordem.FindAsync(id);
            if (ordem == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "NomeCompleto", ordem.ClienteId);
            ViewData["TecnicoId"] = new SelectList(_context.Tecnico, "TecnicoId", "Nome");
            ViewData["ServicoId"] = new SelectList(_context.Servico, "ServicoId", "Descricao");
            ViewData["Valor"] = new SelectList(_context.Servico, "ServicoId", "Valor");
            return View(ordem);
        }

        // POST: Ordems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdemId,ClienteId,TecnicoId,Abertura,ServicoId,Procedimento,Tempo,Taxas,Desconto,Observacao,Status")] Ordem ordem)
        {
            if (id != ordem.OrdemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemExists(ordem.OrdemId))
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
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteID", ordem.ClienteId);
            ViewData["TecnicoId"] = new SelectList(_context.Tecnico, "TecnicoId", "Nome");
            ViewData["ServicoId"] = new SelectList(_context.Servico, "ServicoId", "Descricao");
            ViewData["Valor"] = new SelectList(_context.Servico, "ServicoId", "Valor");
            return View(ordem);
        }

        // GET: Ordems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordem = await _context.Ordem
                .Include(c => c.Cliente).Include(c => c.Tecnico).Include(c => c.Servico)
                .FirstOrDefaultAsync(m => m.OrdemId == id);
            if (ordem == null)
            {
                return NotFound();
            }

            return View(ordem);
        }

        // POST: Ordems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordem = await _context.Ordem.FindAsync(id);
            if (ordem != null)
            {
                _context.Ordem.Remove(ordem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemExists(int id)
        {
            return _context.Ordem.Any(e => e.OrdemId == id);
        }
    }
}
