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
    [ValidationAspect(typeof(RelatedProductValidator))]
    public class RelatedProductService : ServiceRepository<RelatedProduct, RelatedProductDto>, IRelatedProductService
    {
        private readonly IRepository<RelatedProduct> _repository;
        private readonly IMapper _mapper;

        public RelatedProductService(IRepository<RelatedProduct> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<RelatedProductsDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Include(x => x.Product)
                .Include(x => x.RelevantProduct)
                .Filter(filter)
                .ToPagedList<RelatedProduct, RelatedProductsDto>(filter, _mapper));
        }
    }
}