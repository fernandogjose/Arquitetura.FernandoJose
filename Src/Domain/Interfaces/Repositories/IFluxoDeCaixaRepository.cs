using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IFluxoDeCaixaRepository
    {
        int Adicionar(FluxoDeCaixa request);

        void Editar(FluxoDeCaixa request);

        void Deletar(int request);

        FluxoDeCaixa Obter(FluxoDeCaixa request);

        IEnumerable<FluxoDeCaixa> Listar(FluxoDeCaixa request);
    }
}
