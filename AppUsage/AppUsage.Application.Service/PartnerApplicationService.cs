using AppUsage.Application.Contract.Contracts;
using AppUsage.Application.Contract.ViewModels;
using AppUsage.Business.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppUsage.Application.Service
{
    public class PartnerApplicationService : IPartnerApplicationService
    {
        //[Dependency]
        private IPartnerBusinessService _partnerBusinessService { get; set; }

        public PartnerApplicationService(IPartnerBusinessService partnerBusinessService)
        {
            this._partnerBusinessService = partnerBusinessService;
        }

        public IList<PartnerViewModel> Get(string includeProperties = null)
        {
            return PartnerViewModel.Instance.ToContract(this._partnerBusinessService.Get(includeProperties: includeProperties)).ToList();
        }

        public PartnerViewModel GetById(object id)
        {
            return PartnerViewModel.Instance.ToContract(this._partnerBusinessService.GetById(Convert.ToInt32(id)));
        }

        public void Remove(object id)
        {
            this._partnerBusinessService.Remove(Convert.ToInt32(id));
        }

        public PartnerViewModel Save(PartnerViewModel contract)
        {
            return PartnerViewModel.Instance.ToContract(this._partnerBusinessService.Save(PartnerViewModel.Instance.ToEntity(contract)));
        }
    }
}
