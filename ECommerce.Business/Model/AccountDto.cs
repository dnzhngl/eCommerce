using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class AccountDto : IBaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public bool IsBlocked { get; set; }

        public int? GenderId { get; set; }
        public int UserGroupId { get; set; }
        public int RoleId { get; set; }
    }
}