using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Interfaces.Base;
using MovieCom.Service.Models;

namespace MovieCom.Service.Interfaces
{
    public interface IActorService : IBaseService<Actor>
    {
        IEnumerable<ActorModel> GetAll();
        IEnumerable<ActorModel> GetByIds(IEnumerable<Guid> guids);

        ActorModel GetById(Guid id);
    }
}
