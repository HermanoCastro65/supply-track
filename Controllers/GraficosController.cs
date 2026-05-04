using Microsoft.AspNetCore.Mvc;
using SupplyTrack.Data;
using Microsoft.EntityFrameworkCore;

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
            var dados = await _context.Movimentacoes
                .Include(m => m.Mercadoria)
                .ToListAsync();

            return View(dados);
        }
    }
}