using MovieCom.Web.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieCom.Service.Interfaces.Base;
using Unity;

namespace MovieCom.Web.Helpers
{
    public class ServiceHost : IServiceHost
    {
        private readonly IUnityContainer _container;
        private readonly Dictionary<Type, IService> _services;

        public ServiceHost(IUnityContainer unityContainer)
        {
            _container = unityContainer;
            _services = new Dictionary<Type, IService>();
        }

        public T GetService<T>() where T : IService
        {
            if (_services.ContainsKey(typeof(T)))
            {
                return (T)_services[typeof(T)];
            }

            var service = _container.Resolve<T>();
            Register(service);

            return service;
        }

        public void Register<T>(T service) where T : IService
        {
            if (!_services.ContainsKey(typeof(T)))
            {
                _services.Add(typeof(T), service);
            }
        }
    }
}