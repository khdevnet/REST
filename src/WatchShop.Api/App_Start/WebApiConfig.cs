using System.Net.Http.Formatting;
using System.Web.Http;
using Hal.Engine;
using System.Web.Http.Dispatcher;
using WatchShop.Api.Infrastructure.Router;

namespace WatchShop.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
              name: "DefaultApi 1",
              routeTemplate: "{domain}/products/{id}",
              defaults: new { controller = "catalog", action = "GetProduct", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{domain}/{controller}/{id}",
                defaults: new { domain = "home", controller = "home", id = RouteParameter.Optional }
                );

            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));
            ConfigureFormatters();
        }

        private static void ConfigureFormatters()
        {
            MediaTypeFormatterCollection formatters = GlobalConfiguration.Configuration.Formatters;

            GlobalConfiguration.Configuration.Formatters.Remove(formatters.XmlFormatter);
            GlobalConfiguration.Configuration.Formatters.Remove(formatters.JsonFormatter);
            GlobalConfiguration.Configuration.Formatters.Add(new JsonHalMediaTypeFormatter());
        }
    }
}