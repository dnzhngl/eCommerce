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
    [ValidationAspect(typeof(CityValidator))]
    public class CityService : ServiceRepository<City, CityDto>, ICityService
    {
        private readonly IRepository<City> _repository;
        private readonly IMapper _mapper;
        public CityService(IRepository<City> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<CitiesDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Filter(filter).ToPagedList<City, CitiesDto>(filter, _mapper));
        }
    }
}