using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class CityDto : IBaseDto
    {
        public string Name { get; set; }
        public string LicencePlate { get; set; }
        public bool IsBlocked { get; set; }
        public int CountryId { get; set; }
    }
}