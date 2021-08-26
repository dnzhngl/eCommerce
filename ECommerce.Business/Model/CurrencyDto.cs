using System;
using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class CurrencyDto : IBaseDto
    {
        public string CurrencyCode { get; set; }
        public string? Symbol { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
        public bool IsBlocked { get; set; }
    }
}