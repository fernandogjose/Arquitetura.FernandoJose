namespace Application.ViewModels
{
    public class FluxoDeCaixaAdicionarResponseViewModel : BaseResponseViewModel
    {
        public int Id { get; set; }
    }

    public class FluxoDeCaixaEditarResponseViewModel : BaseResponseViewModel
    {

    }

    public class FluxoDeCaixaDeletarResponseViewModel : BaseResponseViewModel
    {
    }

    public class FluxoDeCaixaObterResponseViewModel : BaseResponseViewModel
    {
        public int Id { get; set; }

        public int FluxoDeCaixaTipoId { get; set; }

        public string? Descricao { get; init; }

        public decimal Valor { get; init; }

        public int IdUsuarioCadastro { get; init; }

        public int? IdUsuarioAlteracao { get; init; }

        public DateTime DataCadastro { get; init; } = DateTime.Now;

        public DateTime? DataAlteracao { get; init; } = DateTime.Now;
    }

    public class FluxoDeCaixaListarResponseViewModel : BaseResponseViewModel
    {
        public int Id { get; set; }

        public int FluxoDeCaixaTipoId { get; set; }

        public string? Descricao { get; init; }

        public decimal Valor { get; init; }

        public int IdUsuarioCadastro { get; init; }

        public int? IdUsuarioAlteracao { get; init; }

        public DateTime DataCadastro { get; init; } = DateTime.Now;

        public DateTime? DataAlteracao { get; init; } = DateTime.Now;
    }

    public class FluxoDeCaixaRelatorioConsolidadeDiarioResponseViewModel : BaseResponseViewModel
    {
        public decimal ValorTotalDebito { get; init; }

        public decimal ValorTotalCredito { get; init; }

        public DateTime Data { get; init; }
    }
}
