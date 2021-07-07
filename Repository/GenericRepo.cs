using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Three_Tier.Repository
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public GenericRepo()
        {
            _context = new SqlContext();
        }
        public void Create(TEntity model)
        {
            _context.Entry(model).State = EntityState.Added;
        }

        public void Update(TEntity model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        public void Delete(TEntity model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public bool SaveChange()
        {
            return _context.SaveChanges() > 0;
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            var data = _context.Set<TEntity>().Where(expression);
            return data;
        }

        

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
