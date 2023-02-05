namespace Domain.Models
{
    public class FluxoDeCaixa : Base
    {
        public int FluxoDeCaixaTipoId { get; set; }

        public string? Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime? Data { get; set; }
    }
}
