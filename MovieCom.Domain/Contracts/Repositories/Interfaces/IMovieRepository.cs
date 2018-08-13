using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Domain.Contracts.Repositories.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        IEnumerable<Movie> GetTopByRating(int topCount);
    }
}
