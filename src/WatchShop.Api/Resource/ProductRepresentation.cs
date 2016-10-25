using Hal.Engine;

namespace WatchShop.Api.Resource
{
    public class ProductRepresentation : Representation
    {
        public ProductRepresentation(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public override string Rel
        {
            get { return new Link("products", "~/products/{id}").Rel; }
            set { }
        }

        protected override void CreateHypermedia()
        {
           Href = new Link("products", "~/products/{id}").Href;
        }
    }
}