using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class FavoriteProductDto : IBaseDto
    {
        public int ProductId { get; set; }
        public int AccountId { get; set; }
    }
}