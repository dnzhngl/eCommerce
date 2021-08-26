using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class Setting : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}