namespace RoleWebApi.Information.API.InstanceProviders
{
    using RoleWebApi.Information.API._Code.ExceptionHandling;
    using RoleWebApi.Application.Context.PolicyModule.Service;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.DependencyInjection;
    using RoleWebApi.Application.Context.AuthenticationModule.Service;
    using RoleWebApi.Application.Core.Adapters;
    using RoleWebApi.Application.Context.SecurityModule.Specifications;
    using RoleWebApi.Application.Context.PolicyModule.Specifications;

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
            services.AddTransient<IPolicyAppService, PolicyAppService>();
            services.AddTransient<ISecurityAppService, SecurityAppService>();

            services.AddTransient<IClientAdapter, ClientAdapter>();
            services.AddTransient<IPolicyAdapter, PolicyAdapter>();

            services.AddTransient<IClientSpecification, ClientSpecification>();
            services.AddTransient<IPolicySpecification, PolicySpecification>();

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
