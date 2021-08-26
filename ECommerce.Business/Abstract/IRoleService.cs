using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IRoleService : IServiceRepository<RoleDto>
    {
        Task<PagedList<RolesDto>> GetAllAsync(Filter filter);

    }
}