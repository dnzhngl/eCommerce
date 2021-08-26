using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface ISettingService : IServiceRepository<SettingDto>
    {
        Task<PagedList<SettingsDto>> GetAllAsync(Filter filter);

    }
}