namespace RoleWebApi.Application.Core.Adapters
{
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using System;
    using System.Collections.Generic;

    public class PolicyAdapter : IPolicyAdapter
    {
        public IEnumerable<PolicyDTO> FromPoliciesToPoliciesDTO(IEnumerable<Policy> policies)
        {
            if (policies == null)
                return null;

            List<PolicyDTO> policyDTO = new List<PolicyDTO>();

            foreach (Policy policy in policies)
            {
                policyDTO.Add(FromPolicyToPolicyDTO(policy));
            }

            return policyDTO;
        }

        public PolicyDTO FromPolicyToPolicyDTO(Policy policy)
        {
            if (policy == null)
                return null;

            return new PolicyDTO()
            {
                Id = policy.Id,
                AmountInsured = policy.AmountInsured,
                Email = policy.Email,
                InceptionDate = policy.InceptionDate,
                InstallmentPayment = policy.InstallmentPayment,
                ClientId = policy.ClientId
            };
        }
    }
}
