using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Repositories
{
    public interface IRepository<TEntity> 
    where TEntity:class, IBaseEntity,new()
    {
        /// <summary>
        /// Gets the whole table. GetAll
        /// </summary>
        IQueryable<TEntity> Table { get; }
        
        /// <summary>
        /// Gets all table without caching. GetAll
        /// </summary>
        IQueryable<TEntity> AsNoTracking { get; }
        
        /// <summary>
        /// Checks whether the data with the given id is exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns true if exists.</returns>
        Task<bool> AnyAsync(int id);

        /// <summary>
        /// Gets the entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the entity.</returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Gets the entity that is meets the given filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Inserts the entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Deletes range of entities.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task DeleteRangeAsync(List<TEntity> entities);
    }
}