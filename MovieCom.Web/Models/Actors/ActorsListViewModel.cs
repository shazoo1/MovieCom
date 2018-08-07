using MovieCom.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCom.Web.Models.Actors
{
    public class ActorsListViewModel
    {
        public IEnumerable<ActorModel> ActorsList { get; set; }
    }
}