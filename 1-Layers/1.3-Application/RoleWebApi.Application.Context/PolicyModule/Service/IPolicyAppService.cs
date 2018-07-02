namespace RoleWebApi.Application.Context.PolicyModule.Service
{
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using System.Collections.Generic;

    public interface IPolicyAppService
    {
        ClientDTO GetClientByPolicyId(string policyId);
        IEnumerable<PolicyDTO> ListPoliciesByClientId(string clientId);
        IEnumerable<PolicyDTO> ListPoliciesByName(string name);
    }
}
