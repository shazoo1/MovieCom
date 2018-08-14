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
    public interface ICommentService : IBaseService<Comment>
    {
        void AddOrUpdate(CommentModel commentModel);
        IEnumerable<CommentModel> GetCommentsTree(Guid movieId);
    }
}