namespace Domain.Models
{
    public abstract class Base
    {
        public int Id { get; set; }

        public int IdUsuarioCadastro { get; set; }

        public int? IdUsuarioAlteracao { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime? DataAlteracao { get; set; } = DateTime.Now;

        public List<Erro>? Erros { get; set; }
    }
}
