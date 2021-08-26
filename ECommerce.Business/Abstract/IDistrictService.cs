using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Abstract
{
    public interface IDistrictService : IServiceRepository<DistrictDto>
    {
        Task<PagedList<DistrictsDto>> GetAllAsync(Filter filter);
    }
}