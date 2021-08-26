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
    [ValidationAspect(typeof(SettingValidator))]
    public class SettingService: ServiceRepository<Setting, SettingDto>, ISettingService
    {
        private readonly IRepository<Setting> _repository;
        private readonly IMapper _mapper;

        public SettingService(IRepository<Setting> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<SettingsDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Filter(filter)
                .ToPagedList<Setting, SettingsDto>(filter, _mapper));
        }
    }
}