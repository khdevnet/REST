//using System.Collections.Generic;
//using Hal.Engine;

//namespace WatchShop.Api.Resource
//{
//    public class ReviewRepresentation : Representation
//    {
//        public int Id { get; set; }

//        public int ProductId { get; set; }

//        public string Name { get; set; }

//        public List<ReviewRepresentation> Reviews { get; set; }

//        public override string Rel
//        {
//            get { return LinkTemplates.ProductDetails.GetProductDetail.Rel; }
//            set { }
//        }

//        public override string Href
//        {
//            get { return LinkTemplates.ProductDetails.GetProductDetail.CreateLink(new { id = Id }).Href; }
//            set { }
//        }

//        protected override void CreateHypermedia()
//        {
//            if (Reviews != null)
//                foreach (var rev in Reviews)
//                    Links.Add(LinkTemplates.Reviews.GetProductReview.CreateLink(new { id = rev.ProductId, rid = rev.Id }));
//        }
//    }
//}