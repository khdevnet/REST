using System.Linq;
using System.Web.Http.Routing;
using System.Net.Http;
using System.Web;
using Hal.Engine.Extensibility;
using Hal.Engine.Extensibility.Dto;

namespace Hal.Engine.HypermediaFormatter
{
    public class LinkHypermediaFormatter : IHypermediaFormatter
    {
        public void Formating(IHypermedia resource)
        {
            ILinksResource linkResource = resource as ILinksResource;
            if (linkResource !=null)
            {
                UrlHelper url = new UrlHelper(HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage);
                linkResource.Links = linkResource.Links.Select(x => new Link(x.Rel, url.Content(x.Href))).ToList();
                resource = (IHypermedia)linkResource;
            }
        }
    }
}