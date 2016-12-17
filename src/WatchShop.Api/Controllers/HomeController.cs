using System.Web.Http;
using WatchShop.Api.Resource;
using WatchShop.Domain.Service;

namespace WatchShop.Api.Controllers
{
    public class HomeController : ApiController
    {
        // GET Home
        public HomeRepresentation Get()
        {
            var service = new ProductService();
            var s = service.GetProdutcs();
            return new HomeRepresentation
            {
                Title = "Mens Shop.",
                Welcome = "Mens Shop. Be A man buy for pleasure!!!"
            };
        }
    }
}