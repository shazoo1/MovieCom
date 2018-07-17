using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCom.Common.Enums;

namespace MovieCom.Web.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = Roles.Admin)]
        public ActionResult Add()
        {
            return View();
        }
    }
}