using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Interfaces.Base;

namespace MovieCom.Service.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public void AddItem(T item)
        {
            _uow.Get<T>().Add(item);
        }

        public void AddItems(IEnumerable<T> items)
        {
            _uow.Get<T>().Add(items);
        }

        public IEnumerable<T> GetAll()
        {
            return ((IEnumerable<T>)_uow.Get<T>().GetAll());
        }

        public T GetItem(Guid id)
        {
            return _uow.Get<T>().GetById(id);
        }

        public void RemoveItem(Guid id)
        {
            _uow.Get<T>().Remove(id);
        }

        public void RemoveItem(T item)
        {
            _uow.Get<T>().Remove(item);
        }
    }
}
