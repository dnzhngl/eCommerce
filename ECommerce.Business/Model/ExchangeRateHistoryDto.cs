using System;
using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Model
{
    public class ExchangeRateHistoryDto : IBaseDto
    {
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyId { get; set; }
    }
}