using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IFluxoDeCaixaService
    {
        FluxoDeCaixa Adicionar(FluxoDeCaixa request);

        FluxoDeCaixa Editar(FluxoDeCaixa request);

        FluxoDeCaixa Deletar(int id);

        FluxoDeCaixa Obter(FluxoDeCaixa request);

        IEnumerable<FluxoDeCaixa> Listar(FluxoDeCaixa request);
    }
}
