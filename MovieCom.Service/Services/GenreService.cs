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
    public class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }

        public IEnumerable<GenreModel> GetAll()
        {
            var items = ((IEnumerable<Genre>)_uow.Get<Genre>().GetAll()).ToList();
            return _mapper.Map<IEnumerable<GenreModel>>(items);
        }

        public IEnumerable<GenreModel> GetByIds(IEnumerable<Guid> guids)
        {
            var genres = ((IEnumerable<Genre>)_uow.Get<Genre>().GetAllWhere(x => guids.Contains(x.Id))).ToList();
            return _mapper.Map<IEnumerable<GenreModel>>(genres);
        }
    }
}
