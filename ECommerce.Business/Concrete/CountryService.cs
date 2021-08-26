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

namespace ECommerce.Business.Concrete
{
    [ValidationAspect(typeof(CountryValidator))]
    public class CountryService : ServiceRepository<Country, CountryDto>, ICountryService
    {
        private readonly IRepository<Country> _repository;
        private readonly IMapper _mapper;

        public CountryService(IRepository<Country> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<CountriesDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() =>
                _repository.AsNoTracking
                    .Filter(filter)
                    .ToPagedList<Country, CountriesDto>(filter, _mapper));
        }
    }
}