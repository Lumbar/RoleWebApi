namespace CustomIdentityServer4.UserServices
{
    using IdentityServer4.Extensions;
    using IdentityServer4.Models;
    using IdentityServer4.Services;
    using Microsoft.Extensions.Logging;
    using RoleWebApi.Application.Context.AuthenticationModule.Service;
    using RoleWebApi.Application.Context.PolicyModule.Service;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CustomProfileService : IProfileService
    {
        protected readonly ILogger Logger;
        private readonly ISecurityAppService _securityAppService;

        public CustomProfileService(
            ILogger<CustomProfileService> logger,
            ISecurityAppService securityAppService)
        {
            Logger = logger;
            _securityAppService = securityAppService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var client = _securityAppService.GetClientById(context.Subject.GetSubjectId());
         
            var claims = new List<Claim>
            {
                new Claim("sub", client.Id.ToString()),
                new Claim("name", client.Name),
                new Claim("preferred_username", client.Name),
                new Claim("username", client.Name),
                new Claim("email", client.Email),
                new Claim("role", client.Role)
            };

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = _securityAppService.GetClientById(context.Subject.GetSubjectId());
            context.IsActive = user != null;
        }
    }
}