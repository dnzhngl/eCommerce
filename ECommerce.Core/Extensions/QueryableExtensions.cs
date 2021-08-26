using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using EShop.Core.Models;

namespace EShop.Core.Extensions
{
    public static class QueryableExtensions
    {
        
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> source, Filter filter)
        {
            if (string.IsNullOrEmpty(filter.Keyword)) return source;
            var keyword = filter.Keyword.ToLower();
            var sqlPrefix = "";
            var properties = typeof(TEntity).GetProperties().Where(x => x.PropertyType == typeof(string)).ToList();
            foreach (var property in properties)
            {
                if (sqlPrefix != "") sqlPrefix += " or ";

                sqlPrefix += $"{property.Name}.Contains(\"{keyword}\")";
            }

            source = source.Where(sqlPrefix);
            return source;
        }

        
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, Filter filter)
        {
            if (typeof(TEntity).GetProperties().All(x => !string.Equals(x.Name, filter.OrderByFiled, StringComparison.CurrentCultureIgnoreCase)))
                filter.OrderByFiled = "Id";

            return source.OrderBy($"{filter.OrderByFiled} {(filter.IsDescending ? " desc " : "")}");
        }
        
        public static IQueryable<TEntity> SkipTake<TEntity>(this IQueryable<TEntity> source, Filter filter)
        {
            return source.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);
        }
    }
}