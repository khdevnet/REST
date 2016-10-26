using Hal.Engine;

namespace WatchShop.Api.Resource
{
    public class ProductRepresentation : Representation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        protected override void CreateHypermedia()
        {
            Href = $"products/{Id}";
        }
    }
}