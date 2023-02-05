### Projeto
- **Desenvolvido por:** Fernando Jos�
- **Descri��o:**
Cria��o de uma api de Fluxo de Caixa com um relat�rio consolidado di�rio

### Padr�es e Tecnologias utilizadas
#### BackEnd
- Net Core 6.0
- DDD
- API Rest
- Swagger
- Dapper
- UnitOfWork
- IoC
- C#
- ExceptionMiddleware: Respons�vel por pegar e tratar todos os erros inesperados da aplica��o

#### Testes de Unidade e Testes Integrados
- XUnit
- Moq
- Bogus (faker)

#### Banco de dados
- SQL Server

### Configura��o
#### Pr� requisitos
- Net Core 6.0
- Sql Server

#### BackEnd
- Abrir Terminal
- Acessar a pasta onde est� o projeto
- Acessar a pasta .\Src\Api
- dotnet restore
- dotnet build
- dotnet run

#### Testes de Unidade
- Abrir Terminal
- Acessar a pasta onde est� o projeto
- Acessar a pasta .\Src\UnitTest
- dotnet restore
- dotnet build
- dotnet test

### Configura��o Inicial
Configura��o necess�ria antes de iniciar

#### SqlServer
- Criar um banco de dados a sua escolha (user Arquitetura)
- Executar o script de cria��o de tabelas e carga inicial que est� na pasta Docs/SqlServer/ConfiguracaoInicial

#### BackEnd
- Alterar a connection string no arquivo appsettings.json com a conn que estiver usando

### Ambientes

#### Desenvolvimento
- **Swagger:** https://localhost:7013/swagger/index.html