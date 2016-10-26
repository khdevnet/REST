using Hal.Engine;

namespace WatchShop.Api.Resource
{
    public class CatalogRepresentation : SimpleListRepresentation<ProductRepresentation>
    {
        public override string Rel
        {
            get
            {
                return "ResourceList";
            }

            set
            {
                base.Rel = value;
            }
        }
        protected override void CreateHypermedia()
        {
            Href = "/catalog";

            Links.Add(new Link { Href = Href, Rel = "self" });
            Links.Add(new Link { Rel = "cart", Href = "/cart" });
        }
    }
}