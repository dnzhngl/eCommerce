using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IRuleService : IServiceRepository<RuleDto>
    {
        Task<PagedList<RulesDto>> GetAllAsync(Filter filter);

    }
}