using System.Web.Http;

namespace WatchShop.Api.Home
{
    public class HomeController : ApiController
    {
        // GET Home
        public HomeResponseModel Get()
        {
            return new HomeResponseModel
            {
                Title = "Mens Shop.",
                Welcome = "Mens Shop. Be A man buy for pleasure!!!"
            };
        }
    }
}