using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts.Services;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Models.Entities;
using Service.Services.Base;

namespace Service.Services
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        public MovieService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }

    }
}
