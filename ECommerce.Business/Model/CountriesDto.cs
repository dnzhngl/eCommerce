using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class CountriesDto :IBaseListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool IsBlocked { get; set; }
    }
}