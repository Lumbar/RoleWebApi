namespace RoleWebApi.Application.Core.Adapters
{
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using System.Collections.Generic;

    public class ClientAdapter : IClientAdapter
    {
        public IEnumerable<ClientDTO> FromClientsToClientsDTO(ICollection<Client> clients)
        {
            if (clients == null)
                return null;

            List<ClientDTO> clientsDTO = new List<ClientDTO>();

            foreach (Client client in clients)
            {
                clientsDTO.Add(FromClientToClientDTO(client));
            }

            return clientsDTO;
        }

        public ClientDTO FromClientToClientDTO(Client client)
        {
            if (client == null)
                return null;

            return new ClientDTO()
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Role = client.Role
            };
        }
    }
}
