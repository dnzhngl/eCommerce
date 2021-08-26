using System;
using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class CurrenciesDto :IBaseListDto
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public string? Symbol { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
        public bool IsBlocked { get; set; }
    }
}