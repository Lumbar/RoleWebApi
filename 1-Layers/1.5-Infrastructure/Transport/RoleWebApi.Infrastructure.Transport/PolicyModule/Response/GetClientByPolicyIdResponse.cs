namespace RoleWebApi.Infrastructure.Transport.PolicyModule.Response
{
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using RoleWebApi.Infrastructure.Transport.Common;

    public class GetClientByPolicyIdResponse : BaseResponse
    {
        public ClientDTO Client { get; set; }
    }
}
