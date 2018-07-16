using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Services.Base;
using MovieCom.Domain.Models.Entities;

namespace Domain.Contracts.Services
{
    public interface IMovieService : IBaseService<Movie>
    {

    }
}
