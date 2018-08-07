using AutoMapper;
using MovieCom.Domain.Contracts;
using MovieCom.Service.Interfaces;
using MovieCom.Web.Controllers.Base;
using MovieCom.Web.Models.Actors;
using MovieCom.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCom.Common.Enums;
using System.Collections;
using MovieCom.Service.Models;

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
            var model = new ActorsListViewModel();
            model.ActorsList = _actorService.GetAll();
            return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
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

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Edit(EditActorViewModel model)
        {
            var actorModel = _mapper.Map<ActorModel>(model);
            _actorService.InsertOrUpdate(actorModel);
            return RedirectToAction("Index", "Actors");
        }
        
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Delete(Guid id)
        {
            _actorService.Delete(id);
            return RedirectToAction("Index", "Actors");
        }
    }
}