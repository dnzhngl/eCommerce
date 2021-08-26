using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Enums;

namespace eCommerce.DataAccess.Entities
{
    public class AccountAddress : BaseEntity
    {
        public string Address { get; set; }
        public AccountAddressType AddressType { get; set; }
        
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}