using AppUsage.Business.Contract;
using AppUsage.Business.Service.Base;
using AppUsage.Infrastructure.Data;
using AppUsage.Model.Entities;

namespace AppUsage.Business.Service
{
    public class PartnerBusinessService : ServiceIdBase<Partner>, IPartnerBusinessService
    {
        public PartnerBusinessService(IUnitOfWork<Partner> uow) : base(uow) { }
    }
}
