using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class RulesDto : IBaseListDto
    {
        public int Id { get; set; }
        public string Table { get; set; }

        public bool IsView { get; set; }
        public bool IsInsert { get; set; }
        public bool IsDelete { get; set; }
        public bool IsUpdate { get; set; }
        
        public string Role { get; set; }
    }
}