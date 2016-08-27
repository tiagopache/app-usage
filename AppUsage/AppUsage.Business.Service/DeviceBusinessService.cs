using AppUsage.Business.Contract;
using AppUsage.Business.Service.Base;
using AppUsage.Infrastructure.Data;
using AppUsage.Model.Entities;

namespace AppUsage.Business.Service
{
    public class DeviceBusinessService : ServiceIdBase<Device>, IDeviceBusinessService
    {
        public DeviceBusinessService(IUnitOfWork<Device> uow) : base(uow) { }
    }
}
