using Application.AppServices;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Domain.Validations;
using Infra.Dapper.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Infra.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Repository - Aqui gosto de usar variavel de ambiente ou keyvault do azure para proteger a conexão com o banco de dados
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDbConnection>(x => new SqlConnection(configuration.GetConnectionString("Arquitetura")));
            services.AddTransient<IFluxoDeCaixaRepository, FluxoDeCaixaRepository>();

            // Validação
            services.AddTransient<FluxoDeCaixaValidation>();

            // Service
            services.AddTransient<IFluxoDeCaixaService, FluxoDeCaixaService>();

            // AppService
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IFluxoDeCaixaAppService, FluxoDeCaixaAppService>();
        }
    }
}
