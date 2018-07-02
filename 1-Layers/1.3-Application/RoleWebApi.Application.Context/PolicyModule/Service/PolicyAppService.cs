namespace RoleWebApi.Application.Context.PolicyModule.Service
{
    using RoleWebApi.Application.Context.PolicyModule.Specifications;
    using RoleWebApi.Application.Context.SecurityModule.Specifications;
    using RoleWebApi.Application.Core.Adapters;
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Security.Principal;

    public class PolicyAppService : IPolicyAppService
    {
        private readonly ClaimsPrincipal _principal;
        private readonly IClientSpecification _clientSpecification;
        private readonly IPolicySpecification _policySpecification;
        private readonly IClientAdapter _clientAdapter;
        private readonly IPolicyAdapter _policyAdapter;

        public PolicyAppService(
            IPrincipal principal,
            IClientSpecification clientSpecification,
            IPolicySpecification policySpecification,
            IClientAdapter clientAdapter,
            IPolicyAdapter policyAdapter
            )
        {
            _principal = principal as ClaimsPrincipal;
            _clientSpecification = clientSpecification;
            _policySpecification = policySpecification;
            _clientAdapter = clientAdapter;
            _policyAdapter = policyAdapter;
        }

        public ClientDTO GetClientByPolicyId(string policyId)
        {
            return _clientAdapter.FromClientToClientDTO(_policySpecification.GetClientByPolicyId(policyId));
        }

        public IEnumerable<PolicyDTO> ListPoliciesByClientId(string clientId)
        {
            return _policyAdapter.FromPoliciesToPoliciesDTO(_policySpecification.ListPoliciesByClientId(clientId));
        }

        public IEnumerable<PolicyDTO> ListPoliciesByName(string name)
        {
            return _policyAdapter.FromPoliciesToPoliciesDTO(_policySpecification.ListPoliciesByName(name));
        }
    }
}
