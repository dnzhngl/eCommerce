using System.Collections;
using System.Collections.Generic;
using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool IsBlocked { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}