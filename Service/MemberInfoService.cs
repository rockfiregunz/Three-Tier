using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Three_Tier.Model;
using Three_Tier.Repository;

namespace Three_Tier.Service
{
    public class MemberInfoService : IGenericService<MemberInfo>
    {
        private readonly IGenericRepo<MemberInfo> _repo;
        public MemberInfoService()
        {
            var context = new SqlContext();
            _repo = new MemberInfoRepo(context);
        }

        public bool Create(MemberInfo model)
        {
            try
            {
                  _repo.Create(model);
                 return _repo.SaveChange();
               // return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool Delete(MemberInfo TEntry)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MemberInfo> FindAll(Expression<Func<MemberInfo, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public bool Update(MemberInfo TEntry)
        {
            throw new NotImplementedException();
        }
    }
}
