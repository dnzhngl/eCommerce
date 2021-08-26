using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Model
{
    public class CategoriesDto : IBaseListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsBlocked { get; set; }
        
        public string Parent { get; set; }
    }
}