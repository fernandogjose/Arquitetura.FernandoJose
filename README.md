### Projeto
- **Desenvolvido por:** Fernando José
- **Descrição:**
Criação de uma api de Fluxo de Caixa com um relatório consolidado diário

### Padrões e Tecnologias utilizadas
#### BackEnd
- Net Core 6.0
- DDD
- API Rest
- Swagger
- Dapper
- UnitOfWork
- IoC
- C#
- ExceptionMiddleware: Responsável por pegar e tratar todos os erros inesperados da aplicação

#### Testes de Unidade e Testes Integrados
- XUnit
- Moq
- Bogus (faker)

#### Banco de dados
- SQL Server

### Configuração
#### Pré requisitos
- Net Core 6.0
- Sql Server

#### BackEnd
- Abrir Terminal
- Acessar a pasta onde está o projeto
- Acessar a pasta .\Src\Api
- dotnet restore
- dotnet build
- dotnet run

#### Testes de Unidade
- Abrir Terminal
- Acessar a pasta onde está o projeto
- Acessar a pasta .\Src\UnitTest
- dotnet restore
- dotnet build
- dotnet test

### Configuração Inicial
Configuração necessária antes de iniciar

#### SqlServer
- Criar um banco de dados a sua escolha (user Arquitetura)
- Executar o script de criação de tabelas e carga inicial que está na pasta Docs/SqlServer/ConfiguracaoInicial

#### BackEnd
- Alterar a connection string no arquivo appsettings.json com a conn que estiver usando

### Ambientes

#### Desenvolvimento
- **Swagger:** https://localhost:7013/swagger/index.html