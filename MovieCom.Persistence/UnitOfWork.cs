using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Contracts.Repositories.Interfaces;
using MovieCom.Domain.Models.Entities;
using MovieCom.Persistence.Repositories;

namespace MovieCom.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MovieComDbContext _context;
        private readonly Dictionary<Type, IRepository> _repositories;
        public UnitOfWork()
        {
            _context = new MovieComDbContext();
            _repositories = new Dictionary<Type, IRepository>();
        }

        public IBaseRepository<T> Get<T>() where T : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(T)))
                return _repositories[typeof(T)] as IBaseRepository<T>;
            var repositoryType = typeof(BaseRepository<>).MakeGenericType(typeof(T));
            var repository = (IBaseRepository<T>)Activator.CreateInstance(repositoryType, this._context);
            _repositories.Add(typeof(T), repository);

            return repository;
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
