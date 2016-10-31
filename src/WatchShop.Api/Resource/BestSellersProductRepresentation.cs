//using Hal.Engine;
//using System.Collections.Generic;
//using WatchShop.Api.ViewModel;

//namespace WatchShop.Api.Resource
//{
//    public class BestSellersProductRepresentation : SimpleListRepresentation<ProductRepresentation>
//    {
//        public BestSellersProductRepresentation(IEnumerable<ProductRepresentation> list)
//        {
//            ResourceList = list;
//        }

//        public override string Rel
//        {
//            get { return new Link("products", "~/products/{id}").Rel; }
//            set { }
//        }

//        protected override void CreateHypermedia()
//        {
//           Href = new Link("products", "~/products/{id}").Href;
//        }
//    }
//}