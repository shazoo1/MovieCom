using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Contracts.Repositories.Interfaces;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IBaseRepository<T> Get<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
