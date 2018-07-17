using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Interfaces;
using MovieCom.Service.Services.Base;

namespace MovieCom.Service.Services
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        public MovieService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }

    }
}
