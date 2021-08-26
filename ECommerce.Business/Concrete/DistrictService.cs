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
    [ValidationAspect(typeof(DistrictValidator))]
    public class DistrictService : ServiceRepository<District, DistrictDto>, IDistrictService
    {
        private readonly IRepository<District> _repository;
        private readonly IMapper _mapper;
        public DistrictService(IRepository<District> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<DistrictsDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Include(d => d.City)
                .Filter(filter)
                .ToPagedList<District, DistrictsDto>(filter, _mapper));
        }
    }
}