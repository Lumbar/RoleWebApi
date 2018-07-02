namespace RoleWebApi.Application.Context.AuthenticationModule.Service
{
    using RoleWebApi.Application.Context.SecurityModule.Specifications;
    using RoleWebApi.Application.Core.Adapters;
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Security.Principal;

    public class SecurityAppService : ISecurityAppService
    {
        private readonly ClaimsPrincipal _principal;
        private readonly IClientSpecification _clientSpecification;
        private readonly IClientAdapter _clientAdapter;

        public SecurityAppService(
            IPrincipal principal,
            IClientSpecification clientSpecification,
            IClientAdapter clientAdapter
            )
        {
            _principal = principal as ClaimsPrincipal;
            _clientSpecification = clientSpecification;
            _clientAdapter = clientAdapter;
        }

        public ClientDTO GetClientById(string id)
        {
            return _clientAdapter.FromClientToClientDTO(_clientSpecification.GetClientById(id));
        }

        public ClientDTO GetClientByName(string name)
        {
            return _clientAdapter.FromClientToClientDTO(_clientSpecification.GetClientByName(name));
        }

        public ClientDTO GetClientByEmail(string name)
        {
            return _clientAdapter.FromClientToClientDTO(_clientSpecification.GetClientByEmail(name));
        }

        public ClientPagedList ListClients(string id, string name, string email, string role, int pageIndex, int pageSize)
        {
            IEnumerable<ClientDTO> clients = _clientAdapter.FromClientsToClientsDTO(_clientSpecification.ListClients());

            if (string.IsNullOrEmpty(id) == false)
            {
                clients = clients.Where(q => q.Id.Contains(id));
            }

            if (string.IsNullOrEmpty(name) == false)
            {
                clients = clients.Where(q => q.Name.Contains(name));
            }

            if (string.IsNullOrEmpty(email) == false)
            {
                clients = clients.Where(q => q.Email.Contains(email));
            }

            if (string.IsNullOrEmpty(role) == false)
            {
                clients = clients.Where(q => q.Role.Contains(role));
            }

            ClientPagedList clientPagedList = new ClientPagedList();

            clientPagedList.PageIndex = pageIndex;
            clientPagedList.PageSize = pageSize;
            clientPagedList.TotalPages = clients.Count() / pageSize;
            clientPagedList.TotalCount = clients.Count();
            clientPagedList.Items = clients.Skip(pageIndex * pageSize).Take(pageSize);

            return clientPagedList;
        }

        public bool ValidateClientWithToken(string email)
        {
            return _clientSpecification.GetClientByEmail(email) != null;
        }
    }
}
