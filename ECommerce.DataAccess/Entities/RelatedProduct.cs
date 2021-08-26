using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class RelatedProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int RelevantProductId { get; set; }
        public Product RelevantProduct { get; set; }
    }
}