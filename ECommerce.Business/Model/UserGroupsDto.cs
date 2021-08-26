using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class UserGroupsDto : IBaseListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}