using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MovieCom.Service.Identity;

namespace MovieCom.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected UserManager UserManager => Request.GetOwinContext().GetUserManager<UserManager>();
        protected RoleManager RoleManager => Request.GetOwinContext().GetUserManager<RoleManager>();
        protected SignInManager SignInManager => Request.GetOwinContext().GetUserManager<SignInManager>();
        protected IAuthenticationManager AuthenticationManager => Request.GetOwinContext().Authentication;
    }
}