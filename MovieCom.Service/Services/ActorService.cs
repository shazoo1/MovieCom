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
            var actors = _uow.Get<Actor>().GetAllWhere(x => guids.Contains(x.Id));
            return _mapper.Map<IEnumerable<ActorModel>>(actors);
        }

        public ActorModel GetById(Guid id)
        {
            var actor = _uow.Get<Actor>().GetById(id);
            return _mapper.Map<ActorModel>(actor);
        }

        public void InsertOrUpdate(ActorModel actor)
        {
            var actorEntity = _mapper.Map<Actor>(actor);
            if (actorEntity.Id == Guid.Empty)
            {
                actorEntity.Id = Guid.NewGuid();
                actorEntity.CreatedAt = DateTime.Now;
                _uow.Get<Actor>().Add(actorEntity);
            }
            else
            {
                actorEntity.LastModifiedAt = DateTime.Now;
            _uow.Get<Actor>().Update(actorEntity);
            }
            _uow.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _uow.Get<Actor>().Remove(id);
        }
    }
}
