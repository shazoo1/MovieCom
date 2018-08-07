using System;
using AutoMapper;
using MovieCom.Domain.Contracts;
using MovieCom.Persistence;
using MovieCom.Service.Interfaces;
using MovieCom.Service.Services;
using MovieCom.Web.Mapping;
using Unity;
using Unity.AspNet.Mvc;
using MovieCom.Web.Helpers.Interfaces;
using MovieCom.Web.Helpers;
using Unity.Injection;

namespace MovieCom.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IMovieComDbContext, MovieComDbContext>();
            container.RegisterType<IServiceHost, ServiceHost>(new InjectionConstructor(container));

            //TODO :: Register services
            container.RegisterType<IMovieService, MovieService>();
            container.RegisterType<IGenreService, GenreService>();
            container.RegisterType<IActorService, ActorService>();

            //TODO :: Register instances
            container.RegisterInstance(Mapping.Configuration.Create());
            container.RegisterInstance(Configuration.CreateMapper());
        }
    }
}