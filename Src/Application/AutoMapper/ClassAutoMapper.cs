using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class ClassAutoMapper : Profile
    {
        public ClassAutoMapper()
        {
            // Request
            CreateMap<FluxoDeCaixa, FluxoDeCaixaAdicionarRequestViewModel>().ReverseMap();
            CreateMap<FluxoDeCaixa, FluxoDeCaixaEditarRequestViewModel>().ReverseMap();
            CreateMap<FluxoDeCaixa, FluxoDeCaixaDeletarRequestViewModel>().ReverseMap();
            CreateMap<FluxoDeCaixa, FluxoDeCaixaObterRequestViewModel>().ReverseMap();
            CreateMap<FluxoDeCaixa, FluxoDeCaixaListarRequestViewModel>().ReverseMap();

            // Response
            CreateMap<FluxoDeCaixa, FluxoDeCaixaAdicionarResponseViewModel>().ReverseMap();
            CreateMap<FluxoDeCaixa, FluxoDeCaixaEditarResponseViewModel>().ReverseMap();
            CreateMap<FluxoDeCaixa, FluxoDeCaixaDeletarResponseViewModel>().ReverseMap();
            CreateMap<FluxoDeCaixa, FluxoDeCaixaObterResponseViewModel>().ReverseMap();
            CreateMap<FluxoDeCaixa, FluxoDeCaixaListarResponseViewModel>().ReverseMap();
            CreateMap<Erro, ErroViewModel>();
        }
    }
}
