namespace RoleWebApi.Information.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using RoleWebApi.Information.API.InstanceProviders;
    using RoleWebApi.Infrastructure.Data.Context;
    using RoleWebApi.Infrastructure.Security.CORS;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(
                provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);

            services
                .AddDbContext<PolicyContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("PolicyDatabase")))
                .AddUnitOfWork<PolicyContext>();

            services.ConfigureDI();

            services.AddOptions();
            services.AddSecurity(Configuration);

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:14760/";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "apiInformation";
                });

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAllowAllCORS();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
