using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Three_Tier.Model;
using Three_Tier.Repository;

namespace Three_Tier.Service
{
    class MemberService : IGenericService<Member>
    {
        private readonly MemberRepo _repo;
        public  MemberService()
        {
            _repo   =   new MemberRepo();
        }
        public bool Create(Member model)
        {
            _repo.Create(model);
            throw new NotImplementedException();
        }

        public bool Update(Member model)
        {
            _repo.Update(model);
            throw new NotImplementedException();
        }

        public bool Delete(Member model)
        {
            _repo.Delete(model);
            throw new NotImplementedException();
        }

        public IQueryable<Member> FindAll(Expression<Func<Member, bool>> expression)
        {
            return _repo.FindAll(expression);
        }

        public Member FindOne(Expression<Func<Member, bool>> expression)
        {
            return _repo.FindAll(expression).Single();

        }

        public bool SaveChange()
        {
            return _repo.SaveChange();
        }

        
    }
}
