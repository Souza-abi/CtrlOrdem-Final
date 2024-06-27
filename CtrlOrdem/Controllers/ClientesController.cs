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
    public class ClientesController : Controller
    {
        private readonly CtrlOrdemContext _context;

        public ClientesController(CtrlOrdemContext context)
        {
            _context = context;
        }

        //// GET: Clientes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Cliente.ToListAsync());
        //}


        // Inicio
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Cliente == null)
            {
                return Problem("Tabela Inexistemte");
            }

            var clientes = from m in _context.Cliente select m;

            if (!String.IsNullOrEmpty(searchString))
            {

                clientes = clientes.Where(s => s.NomeCompleto!.Contains(searchString));
            }

            return View(await clientes.ToListAsync());
        }

        // Fim

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteID == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View("Detalhes",cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteID,NomeCompleto,CPFCNPJ,DataNA,Sexo,EstadoCivil,Telefone,Celular,Email,Endereco,Numero,Complemento,Bairro,Cidade,UF,CEP,DataCadastro,Status,Observacao,Contato,TipoContato")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteID,NomeCompleto,CPFCNPJ,DataNA,Sexo,EstadoCivil,Telefone,Celular,Email,Endereco,Numero,Complemento,Bairro,Cidade,UF,CEP,DataCadastro,Status,Observacao,Contato,TipoContato")] Cliente cliente)
        {
            if (id != cliente.ClienteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteID))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteID == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View("Excluir",cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteID == id);
        }
    }
}
