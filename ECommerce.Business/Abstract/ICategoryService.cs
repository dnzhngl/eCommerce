using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryService : IServiceRepository<CategoryDto>
    {
        Task<PagedList<CategoriesDto>> GetAllAsync(Filter filter);
    }
}