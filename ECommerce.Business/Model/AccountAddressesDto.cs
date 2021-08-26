using ECommerce.Core.Signatures;
using eCommerce.DataAccess.Entities;
using eCommerce.DataAccess.Enums;

namespace ECommerce.Business.Model
{
    public class AccountAddressesDto :IBaseListDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public AccountAddressType AddressType { get; set; }
        public string Account { get; set; }
    }
}