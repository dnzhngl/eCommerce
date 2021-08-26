using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class BrandsDto : IBaseListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsBlocked { get; set; }
    }
}