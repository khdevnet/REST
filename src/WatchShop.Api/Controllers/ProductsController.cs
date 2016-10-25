using System.Collections.Generic;
using System.Web.Http;
using WatchShop.Api.Resource;

namespace WatchShop.Api.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public ProductDetailRepresentation Get(int id)
        {
            return new ProductDetailRepresentation
            {
                Id = id,
                Name = "Rolex",
                Reviews = new[] { new ReviewRepresentation { Id = 1, Name = "Review1" } }
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