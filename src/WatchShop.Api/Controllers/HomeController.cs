using System.Web.Http;
using WatchShop.Api.Resource;
using WatchShop.Api.ViewModel;

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

        // GET api/values/5
        public ProductDetailRepresentation Get(int id)
        {
            return new ProductDetailRepresentation
            {
                Id = id,
                Name = "Test"
            };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}