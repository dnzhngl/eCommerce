using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Business.Validators;
using ECommerce.Core.Aspects.CacheAspect;
using ECommerce.Core.Aspects.Validation;
using ECommerce.Core.Extensions;
using ECommerce.Core.Helpers;
using ECommerce.Core.Models;
using eCommerce.DataAccess.Entities;
using eCommerce.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Concrete
{
    [ValidationAspect(typeof(BrandValidator))]
    public class BrandService : ServiceRepository<Brand, BrandDto>, IBrandService
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;
        public BrandService(IRepository<Brand> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<BrandsDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Filter(filter)
                .ToPagedList<Brand, BrandsDto>(filter, _mapper));
        }

        public override async Task<int> InsertAsync(BrandDto dto)
        {
            dto.Url = await GenerateUrl(dto.Description);
            var entity = _mapper.Map<Brand>(dto);
            await _repository.InsertAsync(entity);
            return entity.Id;
        }
        
        /// <summary>
        /// Generates url for the Brand
        /// </summary>
        /// <param name="brandDescription"></param>
        /// <returns></returns>
        private async Task<string> GenerateUrl(string description)
        {
            var nonDiacriticDescription = StringHelper.RemoveDiacritics(description).ToLower(new CultureInfo("ENG"));
            return $"www.{nonDiacriticDescription}.com";
        }
    }
}