using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Validations;

namespace Domain.Services
{
    public class FluxoDeCaixaService : IFluxoDeCaixaService
    {
        private readonly FluxoDeCaixaValidation _fluxoDeCaixaValidation;
        private readonly IFluxoDeCaixaRepository _fluxoDeCaixaRepository;

        public FluxoDeCaixaService(FluxoDeCaixaValidation fluxoDeCaixaValidation, IFluxoDeCaixaRepository fluxoDeCaixaRepository)
        {
            _fluxoDeCaixaValidation = fluxoDeCaixaValidation;
            _fluxoDeCaixaRepository = fluxoDeCaixaRepository;
        }

        public FluxoDeCaixa Adicionar(FluxoDeCaixa request)
        {
            // Crio o objeto de response
            FluxoDeCaixa response = new();

            // Validação de regras de negócio
            _fluxoDeCaixaValidation.ValidarAdicionar(request);
            if (_fluxoDeCaixaValidation.Erros != null && _fluxoDeCaixaValidation.Erros.Any())
            {
                response.Erros = _fluxoDeCaixaValidation.Erros;
                return response;
            }

            // Chama o Repositoy
            response.Id = _fluxoDeCaixaRepository.Adicionar(request);

            // Retorna
            return response;
        }

        public FluxoDeCaixa Deletar(int request)
        {
            // Crio o objeto de response
            FluxoDeCaixa response = new();

            // Validação de regras de negócio
            _fluxoDeCaixaValidation.ValidarDeletar(request);
            if (_fluxoDeCaixaValidation.Erros != null && _fluxoDeCaixaValidation.Erros.Any())
            {
                response.Erros = _fluxoDeCaixaValidation.Erros;
                return response;
            }

            // Chama o Repositoy
            _fluxoDeCaixaRepository.Deletar(request);

            // Retorna
            return response;
        }

        public FluxoDeCaixa Editar(FluxoDeCaixa request)
        {
            // Crio o objeto de response
            FluxoDeCaixa response = new();

            // Validação de regras de negócio
            _fluxoDeCaixaValidation.ValidarEditar(request);
            if (_fluxoDeCaixaValidation.Erros != null && _fluxoDeCaixaValidation.Erros.Any())
            {
                response.Erros = _fluxoDeCaixaValidation.Erros;
                return response;
            }

            // Chama o Repositoy
            _fluxoDeCaixaRepository.Editar(request);

            // Retorna
            return response;
        }

        public IEnumerable<FluxoDeCaixa> Listar(FluxoDeCaixa request)
        {
            IEnumerable<FluxoDeCaixa> response = _fluxoDeCaixaRepository.Listar(request);
            return response;
        }

        public FluxoDeCaixa Obter(FluxoDeCaixa request)
        {
            FluxoDeCaixa response = _fluxoDeCaixaRepository.Obter(request);
            return response;
        }
    }
}
