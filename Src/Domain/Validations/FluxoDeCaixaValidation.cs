using Domain.Models;

namespace Domain.Validations
{
    public class FluxoDeCaixaValidation
    {
        public List<Erro>? Erros { get; private set; }

        private void LimpaErros()
        {
            Erros = new List<Erro>(0);
        }

        private void ValidarId(int valor)
        {
            if (valor <= 0)
            {
                Erros?.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Id é obrigatório"
                });
            }
        }

        private void ValidarDescricao(string? valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Erros?.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Descrição é obrigatório"
                });
            }
        }

        private void ValidarValor(decimal valor)
        {
            if (valor <= 0)
            {
                Erros?.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Valor é obrigatório"
                });
            }
        }

        private void ValidarFluxoDeCaixaTipoId(int valor)
        {
            if (valor == 0)
            {
                Erros?.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Tipo do fluxo de caixa é obrigatório"
                });
            }
        }

        public void ValidarAdicionar(FluxoDeCaixa request)
        {
            LimpaErros();
            ValidarDescricao(request.Descricao);
            ValidarValor(request.Valor);
            ValidarFluxoDeCaixaTipoId(request.FluxoDeCaixaTipoId);
        }

        public void ValidarEditar(FluxoDeCaixa request)
        {
            LimpaErros();
            ValidarId(request.Id);
            ValidarDescricao(request.Descricao);
            ValidarValor(request.Valor);
            ValidarFluxoDeCaixaTipoId(request.FluxoDeCaixaTipoId);
        }

        public void ValidarDeletar(int request)
        {
            LimpaErros();
            ValidarId(request);
        }
    }
}
