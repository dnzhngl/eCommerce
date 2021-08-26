using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class CountryDto : IBaseDto
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool IsBlocked { get; set; }
    }
}