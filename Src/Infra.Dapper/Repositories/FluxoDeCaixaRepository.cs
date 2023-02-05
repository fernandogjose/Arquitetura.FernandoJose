using Dapper;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infra.Dapper.Repositories
{
    public class FluxoDeCaixaRepository : BaseRepository, IFluxoDeCaixaRepository
    {
        public FluxoDeCaixaRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public int Adicionar(FluxoDeCaixa request)
        {
            string sql = "" +
                         " INSERT INTO " +
                         "      FluxoDeCaixa (FluxoDeCaixaTipoId, Descricao, Valor, Data, IdUsuarioCadastro, DataCadastro) " +
                         "      VALUES  (@FluxoDeCaixaTipoId, @Descricao, @Valor, @Data, @IdUsuarioCadastro, @DataCadastro);" +
                         " SELECT SCOPE_IDENTITY();";

            var id = _unitOfWork.Connection.ExecuteScalar<int>(sql, request);
            return id;
        }

        public void Deletar(int request)
        {
            string sql = "" +
                         "  DELETE FluxoDeCaixa" +
                         "  WHERE Id = @Id";

            _unitOfWork.Connection.Execute(sql, new { @Id = request });
        }

        public void Editar(FluxoDeCaixa request)
        {
            string sql = "" +
                         "  UPDATE FluxoDeCaixa SET" +
                         "  FluxoDeCaixaTipoId = @FluxoDeCaixaTipoId" +
                         " ,Descricao = @Descricao" +
                         " ,Valor = @Valor" +
                         " ,Data = @Data" +
                         " ,IdUsuarioAlteracao = @IdUsuarioAlteracao" +
                         " ,DataAlteracao = @DataAlteracao " +
                         " WHERE Id = @Id";

            _unitOfWork.Connection.Execute(sql, request);
        }

        public IEnumerable<FluxoDeCaixa> Listar(FluxoDeCaixa request)
        {
            string sql = $@"SELECT Id, 
                                   FluxoDeCaixaTipoId, 
                                   Descricao, 
                                   Valor, 
                                   IdUsuarioCadastro, 
                                   Data,
                                   DataCadastro, 
                                   IdUsuarioAlteracao, 
                                   DataAlteracao 
                            FROM FluxoDeCaixa 
                            WHERE (Data = @Data or @Data is null)";
            IEnumerable<FluxoDeCaixa> response = _unitOfWork.Connection.Query<FluxoDeCaixa>(sql, request);
            return response;
        }

        public FluxoDeCaixa Obter(FluxoDeCaixa request)
        {
            string sql = "SELECT Id, FluxoDeCaixaTipoId, Descricao, Valor, Data, IdUsuarioCadastro, DataCadastro, IdUsuarioAlteracao, DataAlteracao FROM FluxoDeCaixa WHERE Id = @Id";
            FluxoDeCaixa response = _unitOfWork.Connection.QueryFirst<FluxoDeCaixa>(sql, request);
            return response;
        }
    }
}
