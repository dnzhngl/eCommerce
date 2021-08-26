using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Model
{
    public class DistrictsDto : IBaseListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBlocked { get; set; }

        public string City { get; set; }
    }
}