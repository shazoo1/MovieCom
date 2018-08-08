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
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        IEnumerable<T> GetAllWhere(params Expression<Func<T, bool>>[] predicates);
        void Add(T item);
        void Add(IEnumerable<T> items);
        void Update(T item);
        void Remove(T item);
        void Remove(Guid id);
        IEnumerable<T> GetByIds(IEnumerable<Guid> ids);
    }

    public interface IRepository { }
}
