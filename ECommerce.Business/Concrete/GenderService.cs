using System.Collections.Generic;
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
    
    [ValidationAspect(typeof(GenderValidator))]
    public class GenderService : ServiceRepository<Gender, GenderDto>, IGenderService
    {
        private readonly IRepository<Gender> _repository;
        private readonly IMapper _mapper;
        
        public GenderService(IRepository<Gender> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [RemoveCacheAspect]
        public async Task<PagedList<GendersDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Filter(filter).ToPagedList<Gender, GendersDto>(filter, _mapper));
        }
        
        public async Task<List<GendersDto>> GetAllAsync()
        {
            var table = await _repository.Table.ToListAsync();
            var dto = _mapper.Map<List<Gender>, List<GendersDto>>(table);
            return dto;
        }
        
    }
}