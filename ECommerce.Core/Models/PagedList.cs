using System;
using System.Collections.Generic;

namespace EShop.Core.Models
{
    public class PagedList<TDto> 
        //where TDto : class,IBaseListDto, new()
    {
        public List<TDto> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string LastCachedDate { get; set; }


        public PagedList()
        {
            
        }


        public PagedList(List<TDto> data,int count, Filter filter)
        {
            TotalCount = count;
            PageSize = filter.PageSize;
            CurrentPage = filter.PageNumber;
            TotalPage = (int)Math.Ceiling(count / (decimal)filter.PageSize);
            Data = data;
            LastCachedDate = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");
        }
    }
}