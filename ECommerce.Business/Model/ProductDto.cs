using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class ProductDto : IBaseDto
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int VatRate { get; set; }
        public string Url { get; set; }
        public bool IsBlocked { get; set; }
        
        public int CurrencyId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}