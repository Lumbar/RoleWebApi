namespace RoleWebApi.Application.Context.AuthenticationModule.Service
{
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using System.Collections.Generic;

    public interface ISecurityAppService
    {
        bool ValidateClientWithToken(string email);
        ClientDTO GetClientById(string id);
        ClientDTO GetClientByName(string name);
        ClientDTO GetClientByEmail(string email);
        ClientPagedList ListClients(string id, string name, string email, string role, int pageIndex, int pageSize);
    }
}
