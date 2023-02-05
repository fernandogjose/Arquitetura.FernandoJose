using Domain.Interfaces;
using Domain.Models;

namespace Application.AppServices
{
    public class BaseAppService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CommitRollBack(List<Erro>? erros)
        {
            // Commit ou RollBack
            if (erros != null && erros.Any())
            {
                _unitOfWork.RollBack();
            }
            else
            {
                _unitOfWork.CommitTransaction();
            }
        }
    }
}