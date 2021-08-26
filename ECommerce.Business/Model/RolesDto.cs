using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class RolesDto :IBaseListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
    }
}