using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class ProductGroupLineDto : IBaseDto
    {
        public int ProductGroupId { get; set; }
        public int ProductId { get; set; }
    }
}