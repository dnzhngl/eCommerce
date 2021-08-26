using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Model
{
    public class CitiesDto : IBaseListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicencePlate { get; set; }
        public bool IsBlocked { get; set; }

        public string Country { get; set; }
    }
}