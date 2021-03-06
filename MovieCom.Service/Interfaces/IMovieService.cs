﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Interfaces.Base;
using MovieCom.Service.Models;

namespace MovieCom.Service.Interfaces
{
    public interface IMovieService : IBaseService<Movie>
    {
        void AddOrUpdate(MovieModel movie, IEnumerable<Guid> genres, IEnumerable<Guid> actors);
        MovieModel GetById(Guid id);
        IEnumerable<MovieModel> GetAll();
        void Delete(Guid id);
    }
}
