using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Domain.Contracts.Repositories.Interfaces
{
    public interface IBaseRepository<T> : IRepository where T : BaseEntity
    {
        IQueryable GetAll();
        T GetById(Guid id);
        IQueryable GetAllWhere(params Expression<Func<T, bool>>[] predicates);
        void Add(T item);
        void Add(IEnumerable<T> items);
        void Update(T item);
        void Remove(T item);
        void Remove(Guid id);
    }

    public interface IRepository { }
}
