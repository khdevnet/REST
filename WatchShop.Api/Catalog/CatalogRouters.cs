using System.Web.Http;

namespace WatchShop.Api.Catalog
{
    public static class CatalogRouters
    {
        public static void Map(HttpRouteCollection routers)
        {
            routers.MapHttpRoute(
                 name: "Catalog-product",
                 routeTemplate: "api/catalog/product/{id}",
                 defaults: new { controller = "catalog", action = "GetProduct", id = RouteParameter.Optional });
        }
    }
}