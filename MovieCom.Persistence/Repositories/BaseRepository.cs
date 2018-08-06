using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Contracts.Repositories.Interfaces;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;
        protected static readonly object _locker = new object();
        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }
        public void Add(T item)
        {
            lock (_locker)
            {
                _dbSet.Add(item);
                _context.SaveChanges();
            }
        }

        public void Add(IEnumerable<T> items)
        {
            lock (_locker)
            {
                _dbSet.AddRange(items);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            lock (_locker)
            {
                return _dbSet;
            }
        }

        public IEnumerable<T> GetAllWhere(params Expression<Func<T, bool>>[] predicates)
        {
            IEnumerable<T> items = GetAll();
            lock (_locker)
            {
                foreach (var predicate in predicates)
                {
                    items = _dbSet.Where(predicate);
                }
            }
            return items;
        }

        public T GetById(Guid id)
        {
            lock (_locker)
            {
                return _dbSet.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void Remove(T item)
        {
            lock (_locker)
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
            }
        }

        public void Remove(Guid id)
        {
            lock (_locker)
            {
                var item = GetById(id);
                if (item != null) _dbSet.Remove(item);
                _context.SaveChanges();
            }
        }

        public void Update(T item)
        {
            lock (_locker)
            {
                DbEntityEntry dbEntityEntry = _context.Entry(item);
                if (dbEntityEntry.State == EntityState.Detached)
                {
                    _dbSet.Attach(item);
                }
                dbEntityEntry.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
