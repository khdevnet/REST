using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WatchShop.Api.Infrastructure.HttpActionResults
{
    public class FoundResult : IHttpActionResult
    {
        private readonly string reasonPhrase;

        public FoundResult(string reasonPhrase)
        {
            this.reasonPhrase = reasonPhrase;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Found,
                ReasonPhrase = reasonPhrase
            });
        }
    }
}