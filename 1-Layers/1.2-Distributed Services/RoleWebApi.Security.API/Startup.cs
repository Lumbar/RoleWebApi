namespace RoleWebApi.Security.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using RoleWebApi.Security.API.InstanceProviders;
    using RoleWebApi.Infrastructure.Data.Context;
    using RoleWebApi.Infrastructure.Security.CORS;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Mvc.Formatters.Json;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System.Security.Cryptography.X509Certificates;
    using System.IO;
    using RoleWebApi.Security.API._Code.CustomIdentity;
    using Microsoft.AspNetCore.Http;
    using System.Security.Principal;
    using RoleWebApi.Infrastructure.CrossCutting.Constants;

    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _environment = env;
        }

        private readonly IHostingEnvironment _environment;
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

            var cert = new X509Certificate2(
                Path.Combine(_environment.ContentRootPath, "policyKey.pfx"),
                "",
                X509KeyStorageFlags.MachineKeySet);

            Config.Init(Configuration);

            services.AddIdentityServer()
                .AddSigningCredential(cert)
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddCustomUserStore();

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
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
