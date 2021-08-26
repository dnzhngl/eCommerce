using ECommerce.Core.Signatures;

namespace ECommerce.Business.Model
{
    public class SettingDto : IBaseDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}