using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class DistrictDto : IBaseDto
    {
        public string Name { get; set; }
        public bool IsBlocked { get; set; }

        public int CityId { get; set; }
    }
}