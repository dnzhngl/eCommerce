using System.Collections;
using System.Collections.Generic;
using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class ProductGroup : BaseEntity
    {
        public string Description { get; set; }
        
        public ICollection<ProductGroupLine> ProductGroupLines { get; set; }
    }
}