using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class ProductGroupLinesDto :IBaseListDto
    {
        public int Id { get; set; }
        public string ProductGroup { get; set; }
        public string Product { get; set; }
    }
}