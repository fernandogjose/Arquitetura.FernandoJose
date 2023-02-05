using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    // Obs: Sempre "retorno" um Ok e não uso try catch porque criei um middleware que faz o tratamento de erros (exceptions) da aplicação
    [Route("api/fluxoDeCaixa")]
    [ApiController]
    public class FluxoDeCaixaController : ControllerBase
    {
        private readonly IFluxoDeCaixaAppService _fluxoDeCaixaAppService;

        public FluxoDeCaixaController(IFluxoDeCaixaAppService fluxoDeCaixaAppService)
        {
            _fluxoDeCaixaAppService = fluxoDeCaixaAppService;
        }

        [HttpPost("adicionar")]
        [ProducesResponseType(typeof(FluxoDeCaixaAdicionarResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Adicionar(FluxoDeCaixaAdicionarRequestViewModel request)
        {
            FluxoDeCaixaAdicionarResponseViewModel response = _fluxoDeCaixaAppService.Adicionar(request);
            return Ok(response);
        }

        [HttpPut("editar")]
        [ProducesResponseType(typeof(FluxoDeCaixaEditarResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Editar(FluxoDeCaixaEditarRequestViewModel request)
        {
            FluxoDeCaixaEditarResponseViewModel response = _fluxoDeCaixaAppService.Editar(request);
            return Ok(response);
        }

        [HttpDelete("deletar/{request:int}")]
        [ProducesResponseType(typeof(FluxoDeCaixaDeletarResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Deletar(int request)
        {
            FluxoDeCaixaDeletarResponseViewModel response = _fluxoDeCaixaAppService.Deletar(request);
            return Ok(response);
        }

        [HttpGet("obter/{id:int}")]
        [ProducesResponseType(typeof(FluxoDeCaixaObterResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Obter(int id)
        {
            FluxoDeCaixaObterResponseViewModel response = _fluxoDeCaixaAppService.Obter(new FluxoDeCaixaObterRequestViewModel { Id = id });
            return Ok(response);
        }

        [HttpGet("listar")]
        [ProducesResponseType(typeof(IEnumerable<FluxoDeCaixaListarResponseViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Listar()
        {
            IEnumerable<FluxoDeCaixaListarResponseViewModel> response = _fluxoDeCaixaAppService.Listar(new FluxoDeCaixaListarRequestViewModel());
            return Ok(response);
        }

        [HttpGet("relatorio/consolidado-diario/{data:DateTime}")]
        [ProducesResponseType(typeof(IEnumerable<FluxoDeCaixaListarResponseViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult RelatorioConsolidadeDiario(DateTime data)
        {
            FluxoDeCaixaRelatorioConsolidadeDiarioResponseViewModel response = _fluxoDeCaixaAppService.RelatorioConsolidadoDiario(data);
            return Ok(response);
        }
    }
}
