using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class Role : BaseEntity
    {
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
        
    }
}