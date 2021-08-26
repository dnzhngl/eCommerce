using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class District : BaseEntity
    {
        public string Name { get; set; }
        public bool IsBlocked { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}