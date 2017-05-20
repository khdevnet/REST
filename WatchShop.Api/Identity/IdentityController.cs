using System.Web.Http;
using WatchShop.Api.Identity.Models;
using WatchShop.Domain.Identities.Extensibility;

namespace WatchShop.Api.Identity
{
    public class IdentityController : ApiController
    {
        private readonly ITokenIdentifier tokenIdentifier;

        public IdentityController(ITokenIdentifier tokenIdentifier)
        {
            this.tokenIdentifier = tokenIdentifier;
        }

        [HttpPost]
        public IHttpActionResult Token(IdentityRequestModel identity)
        {
            return Ok(tokenIdentifier.GenerateToken(identity.Email, identity.Password));
        }
    }
}