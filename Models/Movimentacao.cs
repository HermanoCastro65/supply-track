using SupplyTrack.Enums;

namespace SupplyTrack.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }

        public int MercadoriaId { get; set; }
        public Mercadoria? Mercadoria { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }

        public TipoMovimentacao Tipo { get; set; }
        public string Observacao { get; set; } = string.Empty;
    }
}