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
    class MemberRepo : IGenericRepo<Member>
    {
         private DbContext _context;
         public MemberRepo()
         {
             this._context    = new SqlContext();
         }

        public void Create(Member model)
        {
            _context.Entry(model).State = EntityState.Added;
        }

        public void Update(Member model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        public void Delete(Member model)
        {
            _context.Entry(model).State=    EntityState.Deleted;
        }

        public bool SaveChange()
        {
            return _context.SaveChanges() > 0;
        }

        public IQueryable<Member> FindAll(Expression<Func<Member, bool>> expression)
        {
            var data = _context.Set<Member>().Where(expression);
            return data;
        }


        public Member FindOne(Expression<Func<Member, bool>> expression)
        {
            var data    =   FindAll(expression);
            return (data.Count()==1)?data.Single():null;
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
