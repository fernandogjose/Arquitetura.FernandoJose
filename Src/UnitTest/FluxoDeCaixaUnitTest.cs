using Application.AppServices;
using Application.Interfaces;
using Application.ViewModels;
using Bogus;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;
using Domain.Validations;
using Infra.Dapper.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Data;
using System.Data.SqlClient;

namespace UnitTest
{
    public class FluxoDeCaixaUnitTest
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly ServiceProvider _services;
        private IFluxoDeCaixaAppService _fluxoDeCaixaAppService;
        private readonly Mock<IFluxoDeCaixaRepository> _fluxoDeCaixaRepositoryMock;
        private readonly Faker _faker;

        public FluxoDeCaixaUnitTest()
        {
            // Faker
            _faker = new Faker();

            // Mock
            _fluxoDeCaixaRepositoryMock = new Mock<IFluxoDeCaixaRepository>();

            // IoC
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton(_fluxoDeCaixaRepositoryMock.Object);
            _serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            _serviceCollection.AddTransient<IDbConnection>(x => new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Arquitetura;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            _serviceCollection.AddTransient<FluxoDeCaixaValidation>();
            _serviceCollection.AddTransient<IFluxoDeCaixaService, FluxoDeCaixaService>();
            _serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            _serviceCollection.AddTransient<IFluxoDeCaixaAppService, FluxoDeCaixaAppService>();
            _services = _serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public void Deve_Retornar_Uma_Mensagem_Descricao_Obrigatoria_Quando_Nao_Passar_A_Descricao_No_Adicionar()
        {
            // arrange
            _fluxoDeCaixaAppService = _services.GetService<IFluxoDeCaixaAppService>();
            FluxoDeCaixaAdicionarRequestViewModel request = new FluxoDeCaixaAdicionarRequestViewModel
            {
                Descricao = "",
                Valor = _faker.Random.Decimal(1, 100),
                FluxoDeCaixaTipoId = _faker.Random.Int(),
                IdUsuarioCadastro = _faker.Random.Int()
            };

            // act
            FluxoDeCaixaAdicionarResponseViewModel response = _fluxoDeCaixaAppService.Adicionar(request);

            // asset
            Assert.True(response.Erros?.Any(x => x.Descricao == "Descrição é obrigatório" && x.Codigo == 400));
        }

        [Fact]
        public void Deve_Adicionar_Quando_Todos_Os_Campos_Estao_Preenchidos()
        {
            // arrange
            _fluxoDeCaixaAppService = _services.GetService<IFluxoDeCaixaAppService>();
            FluxoDeCaixaAdicionarRequestViewModel request = new FluxoDeCaixaAdicionarRequestViewModel
            {
                Descricao = _faker.Commerce.Product(),
                Valor = _faker.Random.Decimal(1, 100),
                FluxoDeCaixaTipoId = _faker.Random.Int(),
                IdUsuarioCadastro = _faker.Random.Int()
            };

            _fluxoDeCaixaRepositoryMock.Setup(r => r.Adicionar(It.IsAny<FluxoDeCaixa>())).Returns(_faker.Random.Number(1, 100));

            // act
            FluxoDeCaixaAdicionarResponseViewModel response = _fluxoDeCaixaAppService.Adicionar(request);

            // asset
            Assert.True(response.Id > 0);
            Assert.True(!response.Erros?.Any());
        }

        // Fiz este exemplo com Theory para simular uma passagem de parametro 
        [Theory]
        [InlineData("ProdutoA")]
        [InlineData("ProdutoB")]
        [InlineData("ProdutoC")]
        public void Deve_Retornar_Uma_Lista_De_Erros_Quando_So_Passar_A_Descricao(string descricao)
        {
            _fluxoDeCaixaAppService = _services.GetService<IFluxoDeCaixaAppService>();
            FluxoDeCaixaAdicionarRequestViewModel request = new FluxoDeCaixaAdicionarRequestViewModel
            {
                Descricao = descricao,
            };

            FluxoDeCaixaAdicionarResponseViewModel response = _fluxoDeCaixaAppService.Adicionar(request);

            Assert.True(response.Id == 0);
            Assert.True(response.Erros?.Any());
        }

        // TODO:: Incluir outros testes
    }
}
