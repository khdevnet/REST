using Hal.Engine;

namespace WatchShop.Api.Resource
{
    public class ProductRepresentation : Representation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        protected override void CreateHypermedia()
        {
            Links.Add(new Link("self", $"products/{Id}"));
        }
    }
}