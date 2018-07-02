namespace RoleWebApi.Application.Core.Adapters
{
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using System.Collections.Generic;

    public interface IPolicyAdapter
    {
        PolicyDTO FromPolicyToPolicyDTO(Policy policy);
        IEnumerable<PolicyDTO> FromPoliciesToPoliciesDTO(IEnumerable<Policy> policies);
    }
}
