namespace CustomIdentityServer4.UserServices
{
    using IdentityServer4.Validation;
    using IdentityModel;
    using RoleWebApi.Application.Context.AuthenticationModule.Service;
    using RoleWebApi.Application.Context.PolicyModule.Service;
    using System.Threading.Tasks;

    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ISecurityAppService _securityAppService;

        public CustomResourceOwnerPasswordValidator(ISecurityAppService authenticationAppService)
        {
            _securityAppService = authenticationAppService;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_securityAppService.ValidateClientWithToken(context.UserName))
            {
                var client = _securityAppService.GetClientByEmail(context.UserName);

                context.Result = new GrantValidationResult(client.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }

            return Task.FromResult(0);
        }
    }
}
