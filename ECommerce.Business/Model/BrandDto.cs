using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class BrandDto : IBaseDto
    {
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsBlocked { get; set; }
    }
}