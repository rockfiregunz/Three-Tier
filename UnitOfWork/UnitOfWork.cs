using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using Three_Tier.Model;

/// <summary>
/// 參考文章
/// https://ithelp.ithome.com.tw/articles/10157700
/// </summary>
namespace Three_Tier.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private  readonly DbContext _context;
        private bool _disposed;
        private Hashtable _repositories;
 
        public DbContext Context
        {
            get {   return this._context;   }
        }

        public UnitOfWork(DbContext Context)
        {
            this._context = Context;
        }

        public IGenericRepo<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                this._repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!this._repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepo<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepo<T>) _repositories[type];
        }

        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        public bool Save()
        {
            return _context.SaveChanges()>0;
        }

        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        /// <param name="disposing">是否在清理中？</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
