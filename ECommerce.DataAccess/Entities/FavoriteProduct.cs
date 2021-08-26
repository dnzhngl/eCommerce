using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class FavoriteProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
    
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}