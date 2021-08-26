using System.Collections;
using System.Collections.Generic;
using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string LicencePlate { get; set; }
        public bool IsBlocked { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}