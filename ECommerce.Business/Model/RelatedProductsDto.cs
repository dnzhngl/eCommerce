using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Model
{
    public class RelatedProductsDto :IBaseListDto
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string RelevantProduct { get; set; }
    }
}