using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Model
{
    public class ProductsDto : IBaseListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int VatRate { get; set; }
        public string Url { get; set; }
        public bool IsBlocked { get; set; }
        
        public string Currency { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
    }
}