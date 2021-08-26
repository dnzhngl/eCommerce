using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace EShop.Api.Installers.Services
{
    public class SwaggerInstaller:IServiceInstaller, IConfigureInstaller
    {
         public void InstallService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "EShop.API",
                        Version = "v1",
                        Description = ".NET Core 5.0.100",
                        Contact = new OpenApiContact
                        {
                            Name = "EShop Api Project",
                            Url = new Uri("https://www.yeditepesoft.com")
                        }
                    }
                );
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Yetkilendirme, Bearer Seması Kullanılmalıdır.\nÖrn : Authorization: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {securitySchema, new[] {"Bearer"}}
                };
                c.AddSecurityRequirement(securityRequirement);
            });
        }

        public void InstallConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment()) return;
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Service");
                //c.DefaultModelExpandDepth(2);
                //c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);
                //c.DisplayOperationId();
                //c.DisplayRequestDuration();
                //c.DocExpansion(DocExpansion.List);
                c.DocExpansion(DocExpansion.None);
                //c.EnableDeepLinking();
                //c.EnableFilter();
                //c.MaxDisplayedTags(5);
                //c.ShowExtensions();
                //c.EnableValidator();
                //c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Head);
            });
        }
    }
}