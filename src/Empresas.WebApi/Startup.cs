using Empresas.IoasysApiAdapter;
using Empresas.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonteOlimpo.Extensions.Configuration;
using MonteOlimpo.Extensions.Service;
using MonteOlimpo.Filters.Exceptions;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Reflection;

namespace Empresas.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });

            var ioasysApiAdapterConfiguration = Configuration.TryGet<IoasysApiAdapterConfiguration>();
            services.AddExtensionHttpContextAccessor();
            services.AddOauth(Configuration);
            services.AddIoasysApiAdapter(ioasysApiAdapterConfiguration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Ioasys Empresas", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OAuth2Scheme
                {
                    Flow = "password",
                    TokenUrl = "/token",
                    Type = "oauth2"
                });

                // It must be here so the Swagger UI works correctly (Swashbuckle.AspNetCore.SwaggerUI, Version=4.0.1.0)
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                   {
                       {"Bearer", new string[] { }}
                   });
            });

            //Serviços MonteOlimpo https://github.com/mmarlonms/MonteOlimpo
            services.AddExceptionHandling();
            services.AddMonteOlimpoLogging(Configuration);
            services.RegisterAllTypes(GetAditionalAssemblies());
        }

        private IEnumerable<Assembly> GetAditionalAssemblies()
        {
            yield return typeof(AuthService).Assembly;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            // Swagger JSON Doc
            app.UseSwagger();

            // Swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
