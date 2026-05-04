namespace SupplyTrack.Models
{
    public class Mercadoria
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string NumeroRegistro { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public int QuantidadeEstoque { get; set; } = 0;
    }
}