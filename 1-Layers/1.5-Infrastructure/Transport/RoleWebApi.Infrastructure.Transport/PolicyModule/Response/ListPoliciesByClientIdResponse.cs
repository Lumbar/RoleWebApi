namespace RoleWebApi.Infrastructure.Transport.PolicyModule.Response
{
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using RoleWebApi.Infrastructure.Transport.Common;
    using System.Collections.Generic;

    public class ListPoliciesByClientIdResponse : BaseResponse
    {
        public IEnumerable<PolicyDTO> Policies { get; set; }

        public ListPoliciesByClientIdResponse()
        {
            Policies = new List<PolicyDTO>();
        }
    }
}
