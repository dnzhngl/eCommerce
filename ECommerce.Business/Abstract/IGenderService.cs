using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;

namespace ECommerce.Business.Abstract
{
    public interface IGenderService : IServiceRepository<GenderDto>
    {
        Task<PagedList<GendersDto>> GetAllAsync(Filter filter);
        Task<List<GendersDto>> GetAllGendersAsync();
    }
}