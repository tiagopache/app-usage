using AppUsage.Application.Contract.ViewModels.Base;
using System.Collections.Generic;

namespace AppUsage.Application.Contract.Contracts.Base
{
    public interface IApplicationServiceBase<TContract> where TContract : BaseViewModel
    {
        IList<TContract> Get(string includeProperties = null);

        TContract GetById(object id);

        TContract Save(TContract contract);

        void Remove(object id);
    }
}
