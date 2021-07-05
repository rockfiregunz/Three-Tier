using System;
using System.Linq;
using System.Linq.Expressions;

namespace Three_Tier.Repository
{
    interface IGenericRepo<TEntity> : IDisposable where TEntity : class
    {
        void Create(TEntity Entry);
        void Update(TEntity TEntry);
        void Delete(TEntity TEntry);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
        bool SaveChange();
    }
}
 