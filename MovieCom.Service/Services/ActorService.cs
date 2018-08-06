using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Interfaces;
using MovieCom.Service.Interfaces.Base;
using MovieCom.Service.Models;
using MovieCom.Service.Services.Base;

namespace MovieCom.Service.Services
{
    public class ActorService : BaseService<Actor>, IActorService
    {
        public ActorService(IUnitOfWork uow, IMapper mapper) : base (uow, mapper) { }

        public IEnumerable<ActorModel> GetAll()
        {
            var actors = (IEnumerable<Actor>)_uow.Get<Actor>().GetAll();
            return _mapper.Map<IEnumerable<ActorModel>>(actors);
        }

        public IEnumerable<ActorModel> GetByIds(IEnumerable<Guid> guids)
        {
            var actors = (IEnumerable<Actor>)_uow.Get<Actor>().GetAllWhere(x => guids.Contains(x.Id));
            return _mapper.Map<IEnumerable<ActorModel>>(actors);
        }
    }
}
