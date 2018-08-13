using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Contracts.Repositories.Interfaces;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IMovieComDbContext context) : base(context)
        {

        }

        public IEnumerable<Movie> GetTopByRating(int topCount)
        {
            return _dbSet.OrderBy(x => x.Rating).Take(topCount).ToList();
        }
    }
}
