using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Signatures;

namespace ECommerce.Business.Repositories
{
    public interface IServiceRepository<TDto> where TDto: class, IBaseDto, new()
    {
        Task<TDto> GetAsync(int id);
        Task<int> InsertAsync(TDto dto);
        Task UpdateAsync(int id, TDto dto);
        Task DeleteAsync(int id);
        Task DeleteRangeAsync(List<int> listOfId);
        Task RemoveCacheAsync();
    }
}