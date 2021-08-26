using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IFavoriteProductService : IServiceRepository<FavoriteProductDto>
    {
        Task<PagedList<FavoriteProductsDto>> GetAllAsync(Filter filter, int accountId);
    }
}