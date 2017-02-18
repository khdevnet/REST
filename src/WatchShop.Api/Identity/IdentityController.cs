using System.Web.Http;
using WatchShop.Api.Identity.Models;

namespace WatchShop.Api.Identity
{
    public class IdentityController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Token(IdentityRequestModel identity)
        {
            //generate token
            return Ok();
        }
    }
}