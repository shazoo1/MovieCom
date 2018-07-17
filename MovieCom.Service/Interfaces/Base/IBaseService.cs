using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Models.Base;
namespace MovieCom.Service.Interfaces.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetItem(Guid id);
        void AddItem(T item);
        void AddItems(IEnumerable<T> items);
        void RemoveItem(Guid id);
        void RemoveItem(T item);
    }
}
