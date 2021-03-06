using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Api.Installers
{
    public interface IServiceInstaller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        void InstallService(IServiceCollection services);
    }
}