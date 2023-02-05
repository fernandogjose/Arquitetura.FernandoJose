using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.AppServices
{
    public class FluxoDeCaixaAppService : BaseAppService, IFluxoDeCaixaAppService
    {
        private readonly IMapper _mapper;
        private readonly IFluxoDeCaixaService _fluxoDeCaixaService;

        public FluxoDeCaixaAppService(IMapper mapper, IFluxoDeCaixaService fluxoDeCaixaService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = mapper;
            _fluxoDeCaixaService = fluxoDeCaixaService;
        }

        public FluxoDeCaixaAdicionarResponseViewModel Adicionar(FluxoDeCaixaAdicionarRequestViewModel request)
        {
            // Criei o UnitOfWork para mostrar um controle de transação com o dapper quando for preciso
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Faz o mapeamento para a model e chama a service
                FluxoDeCaixa requestModel = _mapper.Map<FluxoDeCaixa>(request);
                FluxoDeCaixa responseModel = _fluxoDeCaixaService.Adicionar(requestModel);

                // Commit ou RollBack
                CommitRollBack(responseModel.Erros);

                // Mapemento do response e retorna para a api
                FluxoDeCaixaAdicionarResponseViewModel response = _mapper.Map<FluxoDeCaixaAdicionarResponseViewModel>(responseModel);
                return response;
            }
        }

        public FluxoDeCaixaDeletarResponseViewModel Deletar(int request)
        {
            // Criei o UnitOfWork para mostrar um controle de transação com o dapper quando for preciso
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Faz o mapeamento para a model e chama a service
                FluxoDeCaixa responseModel = _fluxoDeCaixaService.Deletar(request);

                // Commit ou RollBack
                CommitRollBack(responseModel.Erros);

                // Mapemento do response e retorna para a api
                FluxoDeCaixaDeletarResponseViewModel response = _mapper.Map<FluxoDeCaixaDeletarResponseViewModel>(responseModel);
                return response;
            }
        }

        public FluxoDeCaixaEditarResponseViewModel Editar(FluxoDeCaixaEditarRequestViewModel request)
        {
            // Criei o UnitOfWork para mostrar um controle de transação com o dapper quando for preciso
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Faz o mapeamento para a model e chama a service
                FluxoDeCaixa requestModel = _mapper.Map<FluxoDeCaixa>(request);
                FluxoDeCaixa responseModel = _fluxoDeCaixaService.Editar(requestModel);

                // Commit ou RollBack
                CommitRollBack(responseModel.Erros);

                // Mapemento do response e retorna para a api
                FluxoDeCaixaEditarResponseViewModel response = _mapper.Map<FluxoDeCaixaEditarResponseViewModel>(responseModel);
                return response;
            }
        }

        public IEnumerable<FluxoDeCaixaListarResponseViewModel> Listar(FluxoDeCaixaListarRequestViewModel request)
        {
            FluxoDeCaixa requestModel = _mapper.Map<FluxoDeCaixa>(request);
            IEnumerable<FluxoDeCaixa> responseModel = _fluxoDeCaixaService.Listar(requestModel);
            IEnumerable<FluxoDeCaixaListarResponseViewModel> response = _mapper.Map<IEnumerable<FluxoDeCaixaListarResponseViewModel>>(responseModel);
            return response;
        }

        public FluxoDeCaixaObterResponseViewModel Obter(FluxoDeCaixaObterRequestViewModel request)
        {
            FluxoDeCaixa requestModel = _mapper.Map<FluxoDeCaixa>(request);
            FluxoDeCaixa responseModel = _fluxoDeCaixaService.Obter(requestModel);
            FluxoDeCaixaObterResponseViewModel response = _mapper.Map<FluxoDeCaixaObterResponseViewModel>(responseModel);
            return response;
        }

        public FluxoDeCaixaRelatorioConsolidadeDiarioResponseViewModel RelatorioConsolidadoDiario(DateTime data)
        {
            IEnumerable<FluxoDeCaixa> responseModel = _fluxoDeCaixaService.Listar(new FluxoDeCaixa { Data = data });
            FluxoDeCaixaRelatorioConsolidadeDiarioResponseViewModel response = new()
            {
                ValorTotalCredito = responseModel.Sum(where => where.FluxoDeCaixaTipoId = 1),
                ValorTotalDebito = responseModel.Sum(where => where.FluxoDeCaixaTipoId = 2)
            };

            return response;
        }
    }
}