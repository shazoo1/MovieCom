using AutoMapper;
using MovieCom.Domain.Contracts;
using MovieCom.Service.Interfaces;
using MovieCom.Web.Controllers.Base;
using MovieCom.Web.Models.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCom.Web.Controllers
{
    public class ActorsController : BaseController
    {
        IActorService _actorService;
        public ActorsController(IMapper mapper, IActorService actorSevice) : base(mapper)
        {
            _actorService = actorSevice;
        }
        // GET: Actors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(Guid? id)
        {
            EditActorViewModel model;
            if (id == null)
            {
                model = new EditActorViewModel();
            }
            else
            {
                var actor = _actorService.GetById(id.Value);
                model = _mapper.Map<EditActorViewModel>(actor);
            }
            return View(model);   
        }
    }
}