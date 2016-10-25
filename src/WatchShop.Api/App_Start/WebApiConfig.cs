using System.Net.Http.Formatting;
using System.Web.Http;
using Hal.Engine;

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
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller = "home", id = RouteParameter.Optional });

            MediaTypeFormatterCollection formatters = GlobalConfiguration.Configuration.Formatters;

            GlobalConfiguration.Configuration.Formatters.Remove(formatters.XmlFormatter);
            GlobalConfiguration.Configuration.Formatters.Remove(formatters.JsonFormatter);
            GlobalConfiguration.Configuration.Formatters.Add(new JsonHalMediaTypeFormatter());
        }
    }
}