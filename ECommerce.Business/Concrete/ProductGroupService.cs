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
    [ValidationAspect(typeof(ProductGroupValidator))]
    public class ProductGroupService: ServiceRepository<ProductGroup, ProductGroupDto>, IProductGroupService
    {
        private readonly IRepository<ProductGroup> _repository;
        private readonly IMapper _mapper;

        public ProductGroupService(IRepository<ProductGroup> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [CacheAspect]
        public async Task<PagedList<ProductGroupsDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .ToPagedList<ProductGroup, ProductGroupsDto>(filter, _mapper));
        }
    }
}