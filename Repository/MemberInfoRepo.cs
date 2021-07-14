using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using Three_Tier.Model;
using System.Linq.Expressions;

namespace Three_Tier.Repository
{
    public class MemberInfoRepo : IGenericRepo<MemberInfo>
    {
        private  readonly DbContext _context;
        public MemberInfoRepo(DbContext context)
        {
             this._context    =  context;
        }

        public void Create(MemberInfo model)
        {
            _context.Set<MemberInfo>().Add(model);
        }

        public void Update(MemberInfo model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        public void Delete(MemberInfo model)
        {
            _context.Entry(model).State=    EntityState.Deleted;
        }

        public bool SaveChange()
        {
            return _context.SaveChanges() > 0;
        }

        public IQueryable<MemberInfo> FindAll(Expression<Func<MemberInfo, bool>> expression)
        {
            var data = _context.Set<MemberInfo>().Where(expression);
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
