using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Interfaces.Base;
using MovieCom.Service.Models.Base;

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
    }
}
