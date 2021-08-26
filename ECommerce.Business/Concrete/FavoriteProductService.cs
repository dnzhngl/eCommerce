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
    [ValidationAspect(typeof(FavoriteProductValidator))]
    public class FavoriteProductService : ServiceRepository<FavoriteProduct, FavoriteProductDto>, IFavoriteProductService
    {
        private readonly IRepository<FavoriteProduct> _repository;
        private readonly IMapper _mapper;
        public FavoriteProductService(IRepository<FavoriteProduct> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<FavoriteProductsDto>> GetAllAsync(Filter filter, int accountId)
        {
            return await Task.Run(() => _repository.AsNoTracking
                .Where(f => f.AccountId == accountId)
                .Include(f => f.Product)
                .Include(f => f.Account)
                .Filter(filter)
                .ToPagedList<FavoriteProduct, FavoriteProductsDto>(filter, _mapper));
        }
    }
}