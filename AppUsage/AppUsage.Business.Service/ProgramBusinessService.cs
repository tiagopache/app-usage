using AppUsage.Business.Contract;
using AppUsage.Business.Service.Base;
using AppUsage.Infrastructure.Data;
using AppUsage.Model.Entities;

namespace AppUsage.Business.Service
{
    public class ProgramBusinessService : ServiceIdBase<Program>, IProgramBusinessService
    {
        public ProgramBusinessService(IUnitOfWork<Program> uow) : base(uow) { }
    }
}
