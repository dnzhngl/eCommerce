using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface ICountryService : IServiceRepository<CountryDto>
    {
        Task<PagedList<CountriesDto>> GetAllAsync(Filter filter);
    }
}