using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupplyTrack.Data;
using SupplyTrack.Models;
using SupplyTrack.Enums;

namespace SupplyTrack.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly AppDbContext _context;

        public MovimentacoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Movimentacoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Movimentacoes.Include(m => m.Mercadoria);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Movimentacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.Mercadoria)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: Movimentacoes/Create
        public IActionResult Create()
        {
            ViewData["MercadoriaId"] = new SelectList(_context.Mercadorias, "Id", "Nome");
            ViewData["Tipos"] = new SelectList(Enum.GetValues(typeof(TipoMovimentacao)));
            return View();
        }

        // POST: Movimentacoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MercadoriaId,Quantidade,DataHora,Tipo,Observacao")] Movimentacao movimentacao)
        {
            ViewData["MercadoriaId"] = new SelectList(_context.Mercadorias, "Id", "Nome", movimentacao.MercadoriaId);
            ViewData["Tipos"] = new SelectList(Enum.GetValues(typeof(TipoMovimentacao)), movimentacao.Tipo);

            var mercadoria = await _context.Mercadorias
                .FirstOrDefaultAsync(m => m.Id == movimentacao.MercadoriaId);

            if (mercadoria == null)
            {
                ModelState.AddModelError("", "Mercadoria não encontrada.");
            }

            if (movimentacao.Tipo == TipoMovimentacao.Saida && mercadoria != null)
            {
                if (mercadoria.QuantidadeEstoque < movimentacao.Quantidade)
                {
                    ModelState.AddModelError("", "Estoque insuficiente.");
                }
            }

            if (ModelState.IsValid)
            {
                if (mercadoria != null)
                {
                    if (movimentacao.Tipo == TipoMovimentacao.Entrada)
                    {
                        mercadoria.QuantidadeEstoque += movimentacao.Quantidade;
                    }
                    else if (movimentacao.Tipo == TipoMovimentacao.Saida)
                    {
                        mercadoria.QuantidadeEstoque -= movimentacao.Quantidade;
                    }

                    _context.Update(mercadoria);
                }

                _context.Add(movimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(movimentacao);
        }

        // GET: Movimentacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            ViewData["MercadoriaId"] = new SelectList(_context.Mercadorias, "Id", "Nome", movimentacao.MercadoriaId);
            ViewData["Tipos"] = new SelectList(Enum.GetValues(typeof(TipoMovimentacao)), movimentacao.Tipo);

            return View(movimentacao);
        }

        // POST: Movimentacoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MercadoriaId,Quantidade,DataHora,Tipo,Observacao")] Movimentacao movimentacao)
        {
            if (id != movimentacao.Id)
            {
                return NotFound();
            }

            ViewData["MercadoriaId"] = new SelectList(_context.Mercadorias, "Id", "Id", movimentacao.MercadoriaId);
            ViewData["Tipos"] = new SelectList(Enum.GetValues(typeof(TipoMovimentacao)), movimentacao.Tipo);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoExists(movimentacao.Id))
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

            return View(movimentacao);
        }

        // GET: Movimentacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.Mercadoria)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: Movimentacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            if (movimentacao != null)
            {
                _context.Movimentacoes.Remove(movimentacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportarCSV()
        {
            var dados = _context.Movimentacoes.ToList();
            var csv = "Id,Quantidade,Data\n";

            foreach (var item in dados)
            {
                csv += $"{item.Id},{item.Quantidade},{item.DataHora}\n";
            }

            return File(System.Text.Encoding.UTF8.GetBytes(csv), "text/csv", "relatorio.csv");
        }

        private bool MovimentacaoExists(int id)
        {
            return _context.Movimentacoes.Any(e => e.Id == id);
        }
    }
}