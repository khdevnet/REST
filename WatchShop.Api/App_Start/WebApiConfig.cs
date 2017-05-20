using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WatchShop.Api.Catalog;
using WatchShop.Api.Infrastructure;

namespace WatchShop.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "StartPage",
                routeTemplate: String.Empty,
                defaults: new { controller = "home", id = RouteParameter.Optional });

            CatalogRouters.Map(config.Routes);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "home", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "controller",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "home", id = RouteParameter.Optional });

            config.Services.Replace(typeof(IHttpControllerSelector), new DomainHttpControllerSelector(config));

            ConfigurateFormatters();
        }

        private static void ConfigurateFormatters()
        {
            MediaTypeFormatterCollection formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            GlobalConfiguration.Configuration.Formatters.Remove(formatters.XmlFormatter);
        }
    }
}