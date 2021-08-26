using System;
using System.Collections;
using System.Collections.Generic;
using ECommerce.Core.Signatures;

namespace eCommerce.DataAccess.Entities
{
    public class Currency : BaseEntity
    {
        public string CurrencyCode { get; set; }
        public string? Symbol { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
        public bool IsBlocked { get; set; }

        public ICollection<ExchangeRateHistory> ExchangeRateHistories { get; set; }
    }
}