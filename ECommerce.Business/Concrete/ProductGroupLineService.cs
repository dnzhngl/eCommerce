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
    [ValidationAspect(typeof(ProductGroupLineValidator))]
    public class ProductGroupLineService : ServiceRepository<ProductGroupLine, ProductGroupLineDto>, IProductGroupLineService
    {
        private readonly IRepository<ProductGroupLine> _repository;
        private readonly IMapper _mapper;

        public ProductGroupLineService(IRepository<ProductGroupLine> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<ProductGroupLinesDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Include(x => x.Product)
                .Include(x => x.ProductGroup)
                .Filter(filter)
                .ToPagedList<ProductGroupLine, ProductGroupLinesDto>(filter, _mapper));        
        }
    }
}