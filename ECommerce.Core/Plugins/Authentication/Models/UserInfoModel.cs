using System.Collections.Generic;

namespace EShop.Core.Plugins.Authentication.Models
{
    public class UserInfo
    {
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public bool IsSuperVisor { get; set; }
        public TokenInfo TokenInfo { get; set; }
        public List<UserRule> Rules { get; set; }

        public class UserRule
        {
            public string ModuleName { get; set; }
            public bool Read { get; set; }
            public bool Create { get; set; }
            public bool Update { get; set; }
            public bool Delete { get; set; }
        }
    }
    
}