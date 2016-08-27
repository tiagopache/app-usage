using AppUsage.Infrastructure.Data;
using AppUsage.Infrastructure.Data.Base;
using System;

namespace AppUsage.Business.Service.Base
{
    public abstract class ServiceGuidBase<TEntity> : ServiceBase<TEntity> where TEntity : BaseGuidEntity
    {
        public ServiceGuidBase(IUnitOfWork<TEntity> uow) : base(uow)
        {

        }

        public virtual TEntity GetById(Guid id)
        {
            return this.unitOfWork.Repository.GetById(id);
        }

        public virtual void Remove(Guid id)
        {
            this.unitOfWork.Repository.Delete(id);

            this.unitOfWork.Save();
        }

        public virtual TEntity Save(TEntity toSave)
        {
            var found = this.unitOfWork.Repository.GetById(toSave.Id);

            return this.save(toSave, found);
        }
    }
}
