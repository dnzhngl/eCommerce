using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;
using eCommerce.DataAccess.Enums;

namespace ECommerce.Business.Model
{
    public class AccountAddressDto : IBaseDto
    {
        public string Address { get; set; }
        public AccountAddressType AddressType { get; set; }
        public int AccountId { get; set; }
    }
}