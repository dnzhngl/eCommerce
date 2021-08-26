using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EShop.Core.Models;
using EShop.Core.Signatures;

namespace EShop.Core.Extensions
{
    public static class PagedExtensions
    {
        public static PagedList<TDto> ToPagedList<TEntity, TDto>(this IQueryable<TEntity> source, Filter filter, IMapper mapper)
            where TDto : class, IBaseListDto, new()
            where TEntity : class, IBaseEntity, new()
        {
            var count = source.Count();

            var entities = source.OrderBy(filter).SkipTake(filter).ToList();

            var result = mapper.Map<List<TDto>>(entities);
            return new PagedList<TDto>(result, count, filter);
        }
    }
}