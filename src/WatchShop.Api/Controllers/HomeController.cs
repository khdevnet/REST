using System.Collections.Generic;
using System.Web.Http;
using WatchShop.Api.Resources;

namespace WatchShop.Api.Controllers
{
    public class HomeController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public WatchDetailRepresentation Get(int id)
        {
            return new WatchDetailRepresentation
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