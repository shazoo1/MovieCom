using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Contracts.Repositories.Interfaces;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;
        public BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();

        }
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public IQueryable GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable GetAllWhere(params Expression<Func<T, bool>>[] predicates)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
