using System;
using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class ExchangeRateHistory : BaseEntity
    {
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
        
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}