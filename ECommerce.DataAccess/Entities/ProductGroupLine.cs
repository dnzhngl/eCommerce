using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class ProductGroupLine : BaseEntity
    {
        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}