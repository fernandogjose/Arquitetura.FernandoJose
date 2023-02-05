CREATE TABLE [dbo].[FluxoDeCaixa] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [FluxoDeCaixaTipoId] INT           NOT NULL,
    [Descricao]          VARCHAR (200) NOT NULL,
    [Valor]              DECIMAL (18)  NULL,
    [Data]               DATETIME      NULL,
    [IdUsuarioCadastro]  INT           NULL,
    [IdUsuarioAlteracao] INT           NULL,
    [DataCadastro]       DATETIME      NULL,
    [DataAlteracao]      DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[FluxoDeCaixaTipo] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [Descricao]          VARCHAR (200) NOT NULL,
    [IdUsuarioCadastro]  INT           NULL,
    [IdUsuarioAlteracao] INT           NULL,
    [DataCadastro]       DATETIME      NULL,
    [DataAlteracao]      DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO [dbo].[FluxoDeCaixaTipo] ([Descricao], [IdUsuarioCadastro], [DataCadastro])
VALUES ('Débito', 1, GETDATE())

INSERT INTO [dbo].[FluxoDeCaixaTipo] ([Descricao], [IdUsuarioCadastro], [DataCadastro])
VALUES ('Crédito', 1, GETDATE())