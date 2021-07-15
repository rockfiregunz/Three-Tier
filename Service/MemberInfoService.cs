﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Three_Tier.Model;
using Three_Tier.Repository;

namespace Three_Tier.Service
{
    class MemberInfoService : IGenericService<MemberInfo>
    {
        private readonly IGenericRepo<MemberInfo>  _repo;
        private readonly IUnitOfWork _uow;
        public MemberInfoService()
        {
            _uow            =    new UnitOfWork(new SqlContext());
            _repo           =    new GenericRepo<MemberInfo>(new SqlContext());
        }

      
        public bool Create(MemberInfo model)
        {            
            try
            {
                _uow.Repository<MemberInfo>().Create(model);
                _uow.Save();

                // _repo.Create(model);
                // _repo.SaveChange();
            }
            catch(Exception ex)
            {
                Console.WriteLine("time " + DateTime.Now.ToString("yyyy-MM-dd"));
               throw new Exception(ex.Message);
            } 
            return false;
        }

        public bool Update(MemberInfo model)
        {
            throw new NotImplementedException ();
        }

        public bool Delete(MemberInfo model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MemberInfo> FindAll(Expression<Func<MemberInfo, bool>> expression)
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
