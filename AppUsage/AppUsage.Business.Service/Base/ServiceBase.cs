using AppUsage.Infrastructure.Data;
using AppUsage.Infrastructure.Data.Base;
using AppUsage.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AppUsage.Business.Service.Base
{
    public abstract class ServiceBase<TEntity> where TEntity : BaseEntity
    {
        public ServiceBase(IUnitOfWork<TEntity> uow)
        {
            this.unitOfWork = uow;
        }

        //[Dependency]
        protected IUnitOfWork<TEntity> unitOfWork { get; set; }

        public virtual IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderedBy = null, string includeProperties = null)
        {
            return this.unitOfWork.Repository.Get(filter, orderedBy, includeProperties).ToList();
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            this.unitOfWork.Repository.Delete(entityToDelete);

            this.unitOfWork.Save();
        }

        internal TEntity save(TEntity toSave, TEntity found)
        {
            if (found != null)
            {
                found = toSave.Copy<TEntity>(found);

                found.UpdatedOn = DateTime.Now;

                this.unitOfWork.Repository.Update(found);

                toSave = found.Copy<TEntity>();
            }
            else
                this.unitOfWork.Repository.Insert(toSave);

            this.unitOfWork.Save();

            return toSave;
        }
    }
}
