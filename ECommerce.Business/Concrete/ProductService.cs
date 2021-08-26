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
    [ValidationAspect(typeof(ProductValidator))]
    public class ProductService : ServiceRepository<Product, ProductDto>, IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<ProductsDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.Table
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Currency)
                .Filter(filter)
                .ToPagedList<Product, ProductsDto>(filter, _mapper));
        }

        [CacheAspect]
        public async Task<PagedList<ProductsDto>> GetAllByCategoryAsync(Filter filter, int categoryId)
        {
            return await Task.Run(() => _repository.Table
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Currency)
                .Filter(filter)
                .ToPagedList<Product, ProductsDto>(filter, _mapper));
        }
    }
}