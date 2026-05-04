namespace SupplyTrack.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }

        public int MercadoriaId { get; set; }
        public Mercadoria? Mercadoria { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }

        public string Tipo { get; set; } = string.Empty; // Entrada ou Saída
        public string Observacao { get; set; } = string.Empty;
    }
}