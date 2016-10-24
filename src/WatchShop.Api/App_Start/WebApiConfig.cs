using System.Web.Http;
using WebApi.Hal;

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
                defaults: new { controller = "values", id = RouteParameter.Optional });

            var formatters = GlobalConfiguration.Configuration.Formatters;

            GlobalConfiguration.Configuration.Formatters.Remove(formatters.XmlFormatter);
            GlobalConfiguration.Configuration.Formatters.Add(new JsonHalMediaTypeFormatter());
        }
    }
}