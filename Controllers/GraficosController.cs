using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplyTrack.Data;
using SupplyTrack.Enums;

namespace SupplyTrack.Controllers
{
    public class GraficosController : Controller
    {
        private readonly AppDbContext _context;

        public GraficosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var movimentacoes = await _context.Movimentacoes
                .Include(m => m.Mercadoria)
                .ToListAsync();

            var mercadorias = await _context.Mercadorias.ToListAsync();

            var estoque = mercadorias.Select(m => new
            {
                nome = m.Nome,
                quantidade = m.QuantidadeEstoque
            }).ToList();

            var porMes = movimentacoes
                .GroupBy(m => new { m.Mercadoria!.Nome, m.DataHora.Year, m.DataHora.Month })
                .Select(g => new
                {
                    mercadoria = g.Key.Nome,
                    mes = $"{g.Key.Month}/{g.Key.Year}",
                    entradas = g.Where(x => x.Tipo == TipoMovimentacao.Entrada).Sum(x => x.Quantidade),
                    saidas = g.Where(x => x.Tipo == TipoMovimentacao.Saida).Sum(x => x.Quantidade)
                })
                .OrderBy(x => x.mes)
                .ToList();

            ViewBag.Estoque = estoque;
            ViewBag.PorMes = porMes;

            return View();
        }
    }
}