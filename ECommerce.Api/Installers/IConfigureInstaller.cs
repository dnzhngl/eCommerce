using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace EShop.Api.Installers
{
    public interface IConfigureInstaller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        void InstallConfigure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}