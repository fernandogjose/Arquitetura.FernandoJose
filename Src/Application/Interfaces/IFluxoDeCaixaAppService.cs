using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IFluxoDeCaixaAppService
    {
        FluxoDeCaixaAdicionarResponseViewModel Adicionar(FluxoDeCaixaAdicionarRequestViewModel request);

        FluxoDeCaixaEditarResponseViewModel Editar(FluxoDeCaixaEditarRequestViewModel request);

        FluxoDeCaixaDeletarResponseViewModel Deletar(int request);

        FluxoDeCaixaObterResponseViewModel Obter(FluxoDeCaixaObterRequestViewModel request);

        IEnumerable<FluxoDeCaixaListarResponseViewModel> Listar(FluxoDeCaixaListarRequestViewModel request);

        FluxoDeCaixaRelatorioConsolidadeDiarioResponseViewModel RelatorioConsolidadoDiario(DateTime data);
    }
}
