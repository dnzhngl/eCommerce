using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IAccountService : IServiceRepository<AccountDto>
    {
        Task<PagedList<AccountsDto>> GetAllAsync(Filter filter);
    }
}