using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Contracts.Repositories.Interfaces;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MovieComDbContext _context;
        private readonly Dictionary<Type, IRepository> _repositories;
        public UnitOfWork(MovieComDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, IRepository>();
        }

        public IRepository<T> Get<T>() where T : BaseEntity
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories.Add(typeof(T), (IRepository<T>)Activator.CreateInstance(typeof(T), _context));
            }
            return (IRepository<T>)_repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool _disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
