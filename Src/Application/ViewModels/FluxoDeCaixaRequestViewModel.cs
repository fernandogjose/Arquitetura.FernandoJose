namespace Application.ViewModels
{
    public class FluxoDeCaixaAdicionarRequestViewModel
    {
        public int FluxoDeCaixaTipoId { get; set; }

        public string? Descricao { get; init; }

        public decimal Valor { get; init; }

        public DateTime Data { get; set; }

        public int IdUsuarioCadastro { get; set; }
    }

    public class FluxoDeCaixaEditarRequestViewModel
    {
        public int Id { get; set; }

        public int FluxoDeCaixaTipoId { get; set; }

        public string? Descricao { get; init; }

        public decimal Valor { get; init; }

        public DateTime Data { get; set; }

        public int IdUsuarioAlteracao { get; set; }
    }

    public class FluxoDeCaixaDeletarRequestViewModel
    {
        public int Id { get; set; }
    }

    public class FluxoDeCaixaObterRequestViewModel
    {
        public int Id { get; set; }
    }

    public class FluxoDeCaixaListarRequestViewModel
    {

    }
}
