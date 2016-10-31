using System.Collections.Generic;
using Hal.Engine;

namespace WatchShop.Api.Resource
{
    //public class ProductDetailRepresentation : Representation
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }

    //    public IEnumerable<ReviewRepresentation> Reviews { get; set; }

    //    public override string Rel
    //    {
    //        get { return LinkTemplates.ProductDetails.GetProductDetail.Rel; }
    //        set { }
    //    }

    //    public override string Href
    //    {
    //        get { return LinkTemplates.ProductDetails.GetProductDetail.CreateLink(new { id = Id }).Href; }
    //        set { }
    //    }

    //    protected override void CreateHypermedia()
    //    {
    //        if (Reviews != null)
    //            foreach (var rev in Reviews)
    //                Links.Add(LinkTemplates.Reviews.GetProductReview.CreateLink(new { id = rev.Id, rid = rev.Id }));
    //    }
    //}
}