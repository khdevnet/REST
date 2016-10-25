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
            var bestSellersProducts = new[]
            {
                new ProductRepresentation { Id = 1, Name = "Nabucco Black" },
                new ProductRepresentation { Id = 1, Name = "Classic Le Locle Silver" },
                new ProductRepresentation { Id = 1, Name = "Slimline Silver Dial Brown" },
                new ProductRepresentation { Id = 1, Name = "Melbye Grey Dial Grey Mesh" }
            };
            return new HomeRepresentation
            {
                Title = "Mens Shop.",
                Welcome = "Mens Shop. Be A man buy for pleasure!!!",
                BestSellersProducts = new BestSellersProductRepresentation(bestSellersProducts)
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