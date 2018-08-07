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
using MovieCom.Web.Helpers.Interfaces;
using MovieCom.Service.Services;

namespace MovieCom.Web.Controllers
{
    public class ActorsController : BaseController
    {
        
        public ActorsController(IMapper mapper, IServiceHost serviceHost) : base(mapper, serviceHost)
        {
        }
        // GET: Actors
        public ActionResult Index()
        {
            var actorService = _serviceHost.GetService<ActorService>();
            var model = new ActorsListViewModel();

            model.ActorsList = actorService.GetAll();
            return View(model);
        }

        [Authorize(Roles = Roles.Admin)]
        public ActionResult Edit(Guid? id)
        {
            EditActorViewModel model;
            var actorService = _serviceHost.GetService<ActorService>();

            if (id == null)
            {
                model = new EditActorViewModel();
            }
            else
            {
                var actor = actorService.GetById(id.Value);
                model = _mapper.Map<EditActorViewModel>(actor);
            }
            return View(model);   
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Edit(EditActorViewModel model)
        {
            var actorModel = _mapper.Map<ActorModel>(model);
            var actorService = _serviceHost.GetService<ActorService>();

            actorService.InsertOrUpdate(actorModel);
            return RedirectToAction("Index", "Actors");
        }
        
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Delete(Guid id)
        {
            var actorService = _serviceHost.GetService<ActorService>();

            actorService.Delete(id);
            return RedirectToAction("Index", "Actors");
        }
    }
}