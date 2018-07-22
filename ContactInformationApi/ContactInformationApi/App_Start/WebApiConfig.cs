using ContactInformationApi.App_Start;
using ContactInformationLibrary.BusinessLayer;
using ContactInformationLibrary.DatabaseLayer;
using ContactInformationLibrary.Interface;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace ContactInformationApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IBusinessProvider, BusinessProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IDatabaseProvider, DatabaseProvider>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiWithAction",
            //    routeTemplate: "api/{controller}/{action}",
            //    defaults: new { controllers = "Contacts", action = "GetAll" }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
