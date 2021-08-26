using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.Aspects.CacheAspect;
using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Repositories
{
    public class ServiceRepository<TEntity, TDto> : IServiceRepository<TDto> 
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public ServiceRepository(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public virtual async Task<TDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<int> InsertAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.InsertAsync(entity);
            return entity.Id;
        }

        public virtual async Task UpdateAsync(int id, TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.Id = id;
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task DeleteRangeAsync(List<int> listOfId)
        {
            var entities = await _repository.AsNoTracking.Where(x => listOfId.Contains(x.Id))
                .ToListAsync();
            await _repository.DeleteRangeAsync(entities);
        }

        public virtual async Task RemoveCacheAsync()
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}