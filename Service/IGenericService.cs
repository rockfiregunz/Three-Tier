using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Three_Tier.Service
{
    interface IGenericService<TEntity> where TEntity : class
    {
        void Create(TEntity Entry);
        void Update(TEntity TEntry);
        void Delete(TEntity TEntry);
        TEntity FindOne(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
        bool SaveChange();
    }
}
 