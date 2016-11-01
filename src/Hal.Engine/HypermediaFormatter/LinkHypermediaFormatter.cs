using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using Hal.Engine.Extensibility;
using Hal.Engine.Extensibility.Dto;

namespace Hal.Engine.HypermediaFormatter
{
    public class LinkHypermediaFormatter : IHypermediaFormatter
    {
        public void Formating(IHypermedia resource)
        {
            var linkResource = resource as ILinksHypermedia;

            if (linkResource != null)
            {
                var url = new UrlHelper(HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage);
                linkResource.Links = linkResource.Links.Select(x => new Link(x.Rel, url.Content(x.Href))).ToList();
                resource = (IHypermedia)linkResource;
            }
        }
    }
}