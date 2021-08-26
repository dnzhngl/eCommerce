using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Business.Validators;
using ECommerce.Core.Aspects.CacheAspect;
using ECommerce.Core.Aspects.Validation;
using ECommerce.Core.Extensions;
using ECommerce.Core.Models;
using eCommerce.DataAccess.Entities;
using eCommerce.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Concrete
{
    [ValidationAspect(typeof(ExchangeRateHistoryValidator))]
    public class ExchangeRateHistoryService : ServiceRepository<ExchangeRateHistory, ExchangeRateHistoryDto>, IExchangeRateHistoryService
    {
        private readonly IRepository<ExchangeRateHistory> _repository;
        private readonly IMapper _mapper;

        public ExchangeRateHistoryService(IRepository<ExchangeRateHistory> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [CacheAspect]
        public async Task<PagedList<ExchangeRateHistoriesDto>> GetAllAsync(Filter filter, int currencyId)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Where(e => e.CurrencyId == currencyId)
                .Include(e => e.Currency)
                .Filter(filter)
                .ToPagedList<ExchangeRateHistory, ExchangeRateHistoriesDto>(filter, _mapper));
        }
    }
}