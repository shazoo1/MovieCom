using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Entities.Identity;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Identity;
using MovieCom.Service.Interfaces;
using MovieCom.Service.Models;
using MovieCom.Service.Services.Base;

namespace MovieCom.Service.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public void AddOrUpdate(CommentModel commentModel)
        {
            var repo = _uow.Get<Comment>();
            var commentEntity = repo.GetById(commentModel.Id) ?? new Comment();
            _mapper.Map(commentModel, commentEntity);
            commentEntity.Movie = _uow.Get<Movie>().GetById(commentModel.Movie.Id);
            commentEntity.ReplyTo = _uow.Get<Comment>().GetById(commentModel.ReplyTo.Id);
            commentEntity.User = null;
            if (commentModel.Replies != null)
            {
                var repliesIds = commentModel.Replies.Select(x => x.Id);
                commentEntity.Replies = _uow.Get<Comment>().GetByIds(repliesIds).ToList();
            }
            if (commentModel.Id == Guid.Empty)
            {
                commentEntity.CreatedAt = DateTime.Now;
                commentEntity.Id = Guid.NewGuid();
                commentEntity.LastModifiedAt = null;
                repo.Add(commentEntity);
            }
            else
            {
                commentEntity.LastModifiedAt = DateTime.Now;
            }
            _uow.SaveChanges();
        }

        public IEnumerable<CommentModel> GetCommentsTree(Guid movieId)
        {
            var commentsRepo = _uow.Get<Comment>();
            var comments = commentsRepo.GetAll();//.Where(x => x.Movie.Id == movieId && x.ReplyTo == null).ToList();
            return _mapper.Map<IEnumerable<CommentModel>>(comments).OrderBy(x => x.CreatedAt);
        }
    }
}
