using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Three_Tier.Service
{
    interface IGenericService<TEntity> where TEntity : class
    {
        bool Create(TEntity Entry);
        bool Update(TEntity TEntry);
        bool Delete(TEntity TEntry);
        bool SaveChange();
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
        
    }
}
 