namespace EShop.Core.Plugins.Authentication.Models
{
    public class RegisterRequestModel
    {
        public string LangCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public string Password { get; set; }
    }
}