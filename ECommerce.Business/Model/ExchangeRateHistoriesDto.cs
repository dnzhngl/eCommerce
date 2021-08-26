using System;
using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Model
{
    public class ExchangeRateHistoriesDto : IBaseListDto
    {
        public int Id { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
    }
}