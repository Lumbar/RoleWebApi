namespace RoleWebApi.Security.API.InstanceProviders
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.DependencyInjection;
    using RoleWebApi.Security.API._Code.ExceptionHandling;
    using RoleWebApi.Application.Context.AuthenticationModule.Service;
    using RoleWebApi.Application.Context.SecurityModule.Specifications;
    using RoleWebApi.Application.Core.Adapters;

    public static class ContainerProvider
    {
        public static IServiceCollection ConfigureDI(
            this IServiceCollection services)
        {
            ConfigureContainer(services);
            ConfigureFactories();
            ConfigureProviders(services);

            return services;
        }

        static void ConfigureContainer(IServiceCollection services)
        {
            services.AddTransient<ISecurityAppService, SecurityAppService>();

            services.AddTransient<IClientAdapter, ClientAdapter>();

            services.AddTransient<IClientSpecification, ClientSpecification>();
            
            services.AddScoped<ApiExceptionFilter>();
            services.AddScoped<IInfoRequest, InfoRequest>();
            services.AddScoped<ApiActionFilter>();
        }

        static void ConfigureFactories()
        {

        }

        static void ConfigureProviders(IServiceCollection services)
        {

        }
    }
}
