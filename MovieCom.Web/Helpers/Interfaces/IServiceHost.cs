using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCom.Web.Helpers.Interfaces
{
    public interface IServiceHost
    {
        void Register<T>(T service) where T : IService;
        T GetService<T>() where T : IService;
    }
}
