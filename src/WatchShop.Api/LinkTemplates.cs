using Hal.Engine;

namespace WatchShop.Api
{
    public static class LinkTemplates
    {
        public static class ProductDetails
        {
            public static Link GetProductDetail { get; } = new Link("beerdetail", "~/beerdetail/{id}");
        }

        public static class Reviews
        {
            /// <summary>
            /// Gets /beers/{id}/reviews/{rid}
            /// </summary>
            public static Link GetProductReview { get; } = new Link("review", "~/products/{id}/reviews/{rid}");
        }
    }
}