namespace EShop.Core.Plugins.Authentication.Models
{
    public class JwtCreateModel
    {
   
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool IsSuperVisor { get; set; }

        // generate code - constructor - propları seç
        public JwtCreateModel(int id, string fullName, bool isSuperVisor)
        {
            Id = id;
            FullName = fullName;
            IsSuperVisor = isSuperVisor;
        }
    }
}