using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class CategoryDto : IBaseDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsBlocked { get; set; }

        public int? ParentId { get; set; }
    }
}