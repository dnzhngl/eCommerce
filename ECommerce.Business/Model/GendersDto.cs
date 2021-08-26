using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class GendersDto : IBaseListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}