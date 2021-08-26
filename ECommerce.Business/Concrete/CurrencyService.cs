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
    [ValidationAspect(typeof(CurrencyValidator))]
    public class CurrencyService : ServiceRepository<Currency, CurrencyDto>, ICurrencyService
    {
        private readonly IRepository<Currency> _repository;
        private readonly IMapper _mapper;

        public CurrencyService(IRepository<Currency> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<CurrenciesDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() =>
                _repository.AsNoTracking
                    .Filter(filter)
                    .ToPagedList<Currency, CurrenciesDto>(filter, _mapper));
        }
    }
}