using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IBrandService : IServiceRepository<BrandDto>
    {
        Task<PagedList<BrandsDto>> GetAllAsync(Filter filter);
    }
}