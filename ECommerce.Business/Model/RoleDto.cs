using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class RoleDto :IBaseDto
    {
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
    }
}