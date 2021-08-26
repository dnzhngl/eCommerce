using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Business.Model;
using ECommerce.Business.Repositories;
using ECommerce.Core.Models;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Abstract
{
    public interface IAccountAddressService : IServiceRepository<AccountAddressDto>
    {
        // Paged List dönmek zorunda mı?
        Task<PagedList<AccountAddressesDto>> GetAllAsync (Filter filter);
    }
}