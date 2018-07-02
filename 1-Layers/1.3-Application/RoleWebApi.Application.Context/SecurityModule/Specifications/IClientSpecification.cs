namespace RoleWebApi.Application.Context.SecurityModule.Specifications
{
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using System.Collections.Generic;

    public interface IClientSpecification
    {
        Client GetClientById(string id);
        Client GetClientByName(string name);
        Client GetClientByEmail(string email);
        ICollection<Client> ListClients();
    }
}
