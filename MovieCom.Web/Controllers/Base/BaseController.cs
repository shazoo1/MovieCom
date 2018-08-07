using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MovieCom.Service.Identity;
using MovieCom.Web.Helpers.Interfaces;

namespace MovieCom.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected IMapper _mapper;
        protected UserManager UserManager => Request.GetOwinContext().GetUserManager<UserManager>();
        protected RoleManager RoleManager => Request.GetOwinContext().GetUserManager<RoleManager>();
        protected SignInManager SignInManager => Request.GetOwinContext().GetUserManager<SignInManager>();
        protected IAuthenticationManager AuthenticationManager => Request.GetOwinContext().Authentication;

        protected IServiceHost _serviceHost;

        public BaseController(IMapper mapper, IServiceHost serviceHost)
        {
            _mapper = mapper;
            _serviceHost = serviceHost;
        }
    }
}