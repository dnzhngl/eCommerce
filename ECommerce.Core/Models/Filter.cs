namespace EShop.Core.Models
{
    public class Filter
    {
        private int _pageSize = 100;
        private int _pageNumber;
        private string _keyword;
        private string _orderByFiled;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > 100 ? 100 : value;
        }
        
        public int PageNumber
        {
            get => _pageNumber < 1 ? 1 : _pageNumber;
            set => _pageNumber = value < 1 ? 1 : value;
        }

        public string Keyword
        {
            get => _keyword;
            set => _keyword = value ?? "";
        }
        
        public string OrderByFiled
        {
            get => _orderByFiled ?? "Id";
            set => _orderByFiled = value ?? "Id";
        }

        public bool IsDescending { get; set; }
    }
}