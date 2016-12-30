using System.Web.Http;
using WatchShop.Api.Resource;

namespace WatchShop.Api.Controllers
{
    public class HomeController : ApiController
    {
        // GET Home
        public HomeRepresentation Get()
        {
            return new HomeRepresentation
            {
                Title = "Mens Shop.",
                Welcome = "Mens Shop. Be A man buy for pleasure!!!"
            };
        }
    }
}