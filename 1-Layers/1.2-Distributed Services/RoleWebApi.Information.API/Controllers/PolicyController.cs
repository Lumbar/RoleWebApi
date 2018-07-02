namespace RoleWebApi.Information.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using RoleWebApi.Infrastructure.CrossCutting.Constants;
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using RoleWebApi.Infrastructure.CrossCutting.Exceptions.Domain;
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using RoleWebApi.Infrastructure.Transport.PolicyModule.Request;
    using RoleWebApi.Infrastructure.Transport.PolicyModule.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using RoleWebApi.Application.Context.AuthenticationModule.Service;
    using RoleWebApi.Application.Context.PolicyModule.Service;

    [Authorize]
    public class PolicyController : BaseController
    {
        private readonly ISecurityAppService _securityAppService;
        private readonly IPolicyAppService _policyAppService;

        public PolicyController(ISecurityAppService securityAppService,
            IPolicyAppService policyAppService)
        {
            _securityAppService = securityAppService;
            _policyAppService = policyAppService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public GetClientByIdResponse GetClientById([FromBody]GetClientByIdRequest getClientByIdRequest)
        {
            return new GetClientByIdResponse
            {
                Client = _securityAppService.GetClientById(getClientByIdRequest.ClientId)
            };
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public GetClientByNameResponse GetClientByName([FromBody]GetClientByNameRequest getClientByNameRequest)
        {
            return new GetClientByNameResponse
            {
                Client = _securityAppService.GetClientByName(getClientByNameRequest.ClientName)
            };
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ListPoliciesByNameResponse ListPoliciesByName([FromBody]ListPoliciesByNameRequest listPoliciesByNameRequest)
        {
            return new ListPoliciesByNameResponse
            {
                Policies = _policyAppService.ListPoliciesByName(listPoliciesByNameRequest.ClientName)
            };
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public GetClientByPolicyIdResponse GetClientByPolicyId([FromBody]GetClientByPolicyIdRequest getClientByPolicyIdRequest)
        {
            return new GetClientByPolicyIdResponse
            {
                Client = _policyAppService.GetClientByPolicyId(getClientByPolicyIdRequest.PolicyNumber)
            };
        }

        [HttpPost]
        public ListClientsResponse ListClients([FromBody]ListClientsRequest listClientsRequest)
        {
            return new ListClientsResponse
            {
                Clients = _securityAppService.ListClients(listClientsRequest.Id, listClientsRequest.Name, listClientsRequest.Email, listClientsRequest.Role, listClientsRequest.PageIndex, listClientsRequest.PageSize)
            };
        }

        [HttpPost]
        public ListPoliciesByClientIdResponse ListPoliciesByClientId([FromBody]ListPoliciesByClientIdRequest listPoliciesByClientIdRequest)
        {
            return new ListPoliciesByClientIdResponse
            {
                Policies = _policyAppService.ListPoliciesByClientId(listPoliciesByClientIdRequest.ClientId)
            };
        }
    }
}