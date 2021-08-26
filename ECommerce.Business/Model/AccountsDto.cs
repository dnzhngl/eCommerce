using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class AccountsDto : IBaseListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        
        public string Password { get; set; }

        public bool IsBlocked { get; set; }
        
        public string? Gender { get; set; }
        public string UserGroup { get; set; }
        public string Role { get; set; }
    }
}