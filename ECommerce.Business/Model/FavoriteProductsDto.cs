using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Model
{
    public class FavoriteProductsDto : IBaseListDto
    {
        public string Product { get; set; }
        public string Account { get; set; }
    }
}