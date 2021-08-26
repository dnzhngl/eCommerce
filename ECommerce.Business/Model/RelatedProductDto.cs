using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class RelatedProductDto :IBaseDto
    {
        public int ProductId { get; set; }
        public int RelevantProductId { get; set; }
    }
}