using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Three_Tier.Model;
using Three_Tier.Repository;

namespace Three_Tier.Service
{
    public class MemberService : IGenericService<Member>
    {
        private readonly IGenericRepo<Member> _repo;
        public  MemberService()
        {
            var context  =  new SqlContext();
            _repo   =   new MemberRepo(context);
        }

        public bool Create(Member model)
        {            
            try
            {
                var member = _repo.FindAll(x => x.Name.ToLower().Equals(model.Name.ToLower())).FirstOrDefault();
                if (member == null)
                {
                    _repo.Create(model);
                    return _repo.SaveChange();
                }
                else
                    Console.WriteLine("已有相同名稱");

                return false;
            }
            catch(Exception ex)
            {
                    throw new Exception(ex.Message);
            } 
        }

        public bool Update(Member model)
        {
            try
            {
                var chkdata = _repo.FindAll(x => !x.Id.Equals(model.Id) && x.Name.ToLower().Equals(model.Name.ToLower())).FirstOrDefault();
                if (chkdata == null)
                {
                    var member = _repo.FindAll(x => x.Id.Equals(model.Id)).Single();
                    member.Name = model.Name;
                    _repo.Update(member);
                    return _repo.SaveChange();
                }
                else
                    Console.WriteLine("已有相同名稱");
                
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(Member model)
        {
            try
            {
                var member = _repo.FindAll(x => x.Id.Equals(model.Id)).Single();                 
                _repo.Delete(member);
                return _repo.SaveChange();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<Member> FindAll(Expression<Func<Member, bool>> expression)
        {
            try
            {
                return _repo.FindAll(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool SaveChange()
        {
            return _repo.SaveChange();
        }

        
    }
}
