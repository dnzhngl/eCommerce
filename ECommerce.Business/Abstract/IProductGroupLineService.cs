using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IProductGroupLineService : IServiceRepository<ProductGroupLineDto>
    {
        Task<PagedList<ProductGroupLinesDto>> GetAllAsync(Filter filter);
    }
}