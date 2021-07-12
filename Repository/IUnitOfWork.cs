using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Three_Tier.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool Save();
        IGenericRepo<T> Repository<T>() where T : class; 
    }
}
