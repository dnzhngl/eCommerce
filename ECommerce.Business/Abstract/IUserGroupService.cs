using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IUserGroupService : IServiceRepository<UserGroupDto>
    {
        Task<PagedList<UserGroupsDto>> GetAllAsync(Filter filter);
    }
}