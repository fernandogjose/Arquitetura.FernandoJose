using Domain.Interfaces;

namespace Infra.Dapper.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly string _connectionString;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork?.Connection.Dispose();
        }
    }
}
