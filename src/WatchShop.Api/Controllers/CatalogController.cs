//using System.Web.Http;
//using WatchShop.Api.Resource;

//namespace WatchShop.Api.Controllers
//{
//    public class CatalogController : ApiController
//    {
//        // GET api/products
//        public CatalogRepresentation Get()
//        {
//            return new CatalogRepresentation
//            {
//                ResourceList = new[]
//            {
//                new ProductRepresentation
//                {
//                     Id = 1,
//                      Name = "Product 1"
//                },
//                new ProductRepresentation
//                {
//                     Id = 2,
//                      Name = "Product 2"
//                },
//                new ProductRepresentation
//                {
//                     Id = 3,
//                     Name = "Product 3"
//                }
//            }
//            };
//        }

//        // GET api/values/5
//        public ProductDetailRepresentation Get(int id)
//        {
//            return new ProductDetailRepresentation
//            {
//                Id = id,
//                Name = "Rolex",
//                Reviews = new[] { new ReviewRepresentation { Id = 1, Name = "Review1" } }
//            };
//        }

//        // POST api/values
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/values/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/values/5
//        public void Delete(int id)
//        {
//        }
//    }
//}