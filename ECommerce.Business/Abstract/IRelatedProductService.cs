using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Abstract
{
    public interface IRelatedProductService : IServiceRepository<RelatedProductDto>
    {
        Task<PagedList<RelatedProductsDto>> GetAllAsync(Filter filter);
    }
}