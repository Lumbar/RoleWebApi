namespace RoleWebApi.Application.Core.Adapters
{
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using System.Collections.Generic;

    public interface IClientAdapter
    {
        ClientDTO FromClientToClientDTO(Client client);
        IEnumerable<ClientDTO> FromClientsToClientsDTO(ICollection<Client> clients);
    }
}
