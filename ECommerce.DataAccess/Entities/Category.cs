using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsBlocked { get; set; }

        public int? ParentId { get; set; }
        public Category Parent { get; set; }
    }
}