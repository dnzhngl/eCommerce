using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IProductGroupService : IServiceRepository<ProductGroupDto>
    {
        Task<PagedList<ProductGroupsDto>> GetAllAsync(Filter filter);
    }
}