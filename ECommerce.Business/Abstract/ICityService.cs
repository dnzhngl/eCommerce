using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface ICityService : IServiceRepository<CityDto>
    {
        Task<PagedList<CitiesDto>> GetAllAsync(Filter filter);
    }
}