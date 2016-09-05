using AppUsage.Infrastructure.Data;
using AppUsage.Infrastructure.Data.Base;
using AppUsage.Infrastructure.Extensions;
using AppUsage.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AppUsage.Business.Service.Base
{
    public abstract class ServiceBase<TEntity> where TEntity : BaseEntity, IDisposable
    {
        private static int _instanceSequence = 0;
        private bool disposed = true;

        public ServiceBase(IUnitOfWork<TEntity> uow)
        {
            _instanceSequence++;

            UnityEventLogger.Log.CreateUnityMessage($"{this.GetType().ToString()} {_instanceSequence}");

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

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            UnityEventLogger.Log.LogUnityMessage($"Disposing {this.GetType().ToString()} {_instanceSequence}");

            if (!this.disposed)
            {
                if (disposing)
                {
                    // do the dispose of other objects here
                }

                UnityEventLogger.Log.DisposeUnityMessage($"{this.GetType().ToString()} {_instanceSequence}");

                _instanceSequence--;

                this.disposed = true;
            }
        }
    }
}
