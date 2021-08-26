using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class SettingsDto : IBaseListDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}