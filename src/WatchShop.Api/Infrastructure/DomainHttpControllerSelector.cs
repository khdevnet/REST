using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace WatchShop.Api.Infrastructure
{
    public class DomainHttpControllerSelector : IHttpControllerSelector
    {
        private const string ControllerKey = "controller";
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllersDiscriptor;

        public DomainHttpControllerSelector(HttpConfiguration httpConfiguration)
        {
            _controllersDiscriptor = GetControllersDiscriptor(httpConfiguration);
        }

        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllersDiscriptor.Value;
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            IHttpRouteData routeData = request.GetRouteData();
            if (routeData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            object controllerName;
            if (!routeData.Values.TryGetValue(ControllerKey, out controllerName))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return GetControllerDescriptor((string)controllerName);
        }

        private HttpControllerDescriptor GetControllerDescriptor(string controllerName)
        {
            HttpControllerDescriptor controllerDescriptor;
            if (_controllersDiscriptor.Value.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        private Lazy<Dictionary<string, HttpControllerDescriptor>> GetControllersDiscriptor(HttpConfiguration httpConfiguration)
        {
            IAssembliesResolver assembliesResolver = httpConfiguration.Services.GetAssembliesResolver();
            IHttpControllerTypeResolver controllersResolver = httpConfiguration.Services.GetHttpControllerTypeResolver();

            var controllersDiscriptor = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);
            foreach (Type controllerType in controllersResolver.GetControllerTypes(assembliesResolver))
            {
                string controllerName = GetControllerName(controllerType.Name);
                if (!controllersDiscriptor.Keys.Contains(controllerName))
                {
                    controllersDiscriptor[controllerName] = new HttpControllerDescriptor(httpConfiguration, controllerType.Name, controllerType);
                }
            }
            return new Lazy<Dictionary<string, HttpControllerDescriptor>>(() => controllersDiscriptor);
        }

        private static string GetControllerName(string controllerTypeName)
        {
            return controllerTypeName.Remove(controllerTypeName.Length - DefaultHttpControllerSelector.ControllerSuffix.Length);
        }
    }
}