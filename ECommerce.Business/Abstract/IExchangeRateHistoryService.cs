using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IExchangeRateHistory : IServiceRepository<ExchangeRateHistoryDto>
    {
        Task<PagedList<ExchangeRateHistoriesDto>> GetAllAsync(Filter filter);
    }
}