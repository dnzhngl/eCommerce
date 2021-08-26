using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IProductService : IServiceRepository<ProductDto>
    {
        Task<PagedList<ProductsDto>> GetAllAsync(Filter filter);
        Task<PagedList<ProductsDto>> GetAllByCategoryAsync(Filter filter, int categoryId);
    }
}