namespace RoleWebApi.Application.Context.PolicyModule.Specifications
{
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using System.Collections.Generic;

    public interface IPolicySpecification
    {
        Client GetClientByPolicyId(string policyId);
        IEnumerable<Policy> ListPoliciesByClientId(string clientId);
        IEnumerable<Policy> ListPoliciesByName(string name);
        IEnumerable<Policy> ListPolicies();
    }
}
